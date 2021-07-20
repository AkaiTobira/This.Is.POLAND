using System.Collections.Generic;
using UnityEngine;

public static class UnitsManager{
    static List<Entity> units = new List<Entity>();
    public static int RegisterUnit( Entity unit ){
        for( int i = 0; i < units.Count; i++){
            if(units[i] == null){
                units[i] = unit;
                return i;
            }
        }
        units.Add(unit);
        return units.Count-1;
    }

    public static Entity GetUnit( int unit_ID ){
        return (unit_ID < units.Count) ? units[unit_ID] : null;
    }

    public static void RemoveUnit( int unit_ID){
        if(unit_ID < units.Count){
            units[unit_ID] = null;
        }
    }
}

public enum ControllType{

    Player1,
    Player2,
    AI,
}

public static class ControllSpawner{

    public static APlayerInput Get(ControllType type){
        switch (type)
        {
            case ControllType.Player1: return new Player1Input();
            case ControllType.Player2: return new Player2Input();
            case ControllType.AI:      return new Player2Input();
        }
        return null;
    }
}

public class Player : Entity, IListenToEvents
{
    private FSM playerController;
    float reactionToGetHitTimer = 1.0f;
    bool isDead;

    [SerializeField] ControllType controllerType;


    public void OnGameEvent( GameEvent gameEvent){
        if( isDead ) return;

        switch( gameEvent.type ){
            case GameEventType.PlayerGetsHit:
                if( reactionToGetHitTimer < 0){
                    playerController.ChangeToState(new HurtState(this));
                    reactionToGetHitTimer = InvincibleTime;
                    GameEventSystem.RiseEvent( new GameEvent(GameEventType.LoseHp));
                }
            break;
        }
    }

    public override void Start() {
        base.Start();
        GameEventSystem.RegisterListener(this, GameEventType.PlayerGetsHit);
        InputController =  ControllSpawner.Get(controllerType);
        playerController = new FSM(new IdleState(this));
    }

    public override void Update() {
        playerController.Update();
        reactionToGetHitTimer -= Time.deltaTime;
        base.Update();
    }

    void FixedUpdate() {
        playerController.FixedUpdate();
    }
}
