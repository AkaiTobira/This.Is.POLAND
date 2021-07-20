using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState, IState
{
    public IdleState(Entity gameObject) : base(gameObject){}
    public void OnEnter(){}
    public void OnExit(){}
    public override void HandleInput(){
        if( Controll.isJumpPressed() && Controll.CanJump()){
            _stateMachine.ChangeToState( new JumpState(_entity));
        }else  if( Controll.isLeftHold() || Controll.isRightHold()){
            _stateMachine.ChangeToState( new MoveState(_entity));
        }
    }
    public override void ProcessGraphics(){
        AnimatorExt.SetBool("OnGround", true);
    }
    public override void ProcessPhysics(){}
}
