using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState, IState
{
    const string ANIMATION_RESTART = "Restart";
    const string ANIMATION_DEAD = "Dead";

    public DeadState(Entity gameObject) : base(gameObject){}
    public void OnEnter(){
        AnimatorExt.SetTrigger(ANIMATION_DEAD);
    }
    public void OnExit(){
        AnimatorExt.SetTrigger(ANIMATION_RESTART);
    }
    public override void HandleInput(){}
    public override void ProcessGraphics(){}
    public override void ProcessPhysics(){}
}
