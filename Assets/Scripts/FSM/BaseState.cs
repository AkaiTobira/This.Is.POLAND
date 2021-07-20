using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class UnitBaseState: BaseState{

    public UnitBaseState(Entity entity): base(entity){}

    new protected UnitFSM _stateMachine;

    public void SetFSM(UnitFSM stateMachine)
    {
        _stateMachine = stateMachine;
    }
}


public abstract class BaseState
{
    protected Entity _entity;
    protected FSM _stateMachine;

    protected AnimatorExtended AnimatorExt;
    protected UnitDetector Physic;
    protected APlayerInput Controll;

    public BaseState(Entity entity)
    {
        _entity = entity;

        AnimatorExt = _entity.AnimatorExt;
        Physic      = _entity.Detector;
        Controll    = _entity.InputController;
    }
    public void SetFSM(FSM stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public void Update()
    {
        if(Controll == null){
            Debug.Log("Controller is not set, blocking StateProcessing");
            return;
        }

        if(Physic == null){
            Debug.Log("Physic is not set, blocking StateProcessing");
            return;
        }

        if(AnimatorExt == null){
            Debug.Log("AnimatorExt is not set, blocking StateProcessing");
            return;
        }

        HandleInput();
        ProcessGraphics();
        Controll.Update();
    }

    public void FixedUpdate()
    {
        ProcessPhysics();
    }

    public abstract void HandleInput();
    public abstract void ProcessPhysics();
    public abstract void ProcessGraphics();

}

