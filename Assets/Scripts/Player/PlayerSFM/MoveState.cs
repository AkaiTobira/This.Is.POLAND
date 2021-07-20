using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState, IState
{
    public MoveState(Entity gameObject) : base(gameObject){}
    public void OnEnter(){
        Physic.Move(Controll.GetHorizontalAxisSign());
        AnimatorExt.SetBool("Moving", true);
    }
    public void OnExit(){
        AnimatorExt.SetBool("Moving", false);
    }
    public override void HandleInput(){
        if(!Controll.isLeftHold() && !Controll.isRightHold()){
            _stateMachine.ChangeToState( new IdleState(_entity));
        }else if( Controll.isJumpPressed()  && Controll.CanJump()){
            _stateMachine.ChangeToState( new JumpState(_entity));
        }
    }
    public override void ProcessGraphics(){
        AnimatorExt.UpdateSide(Controll.GetHorizontalAxisSign());
    }
    public override void ProcessPhysics(){
        Physic.Move(Controll.GetHorizontalAxisSign());
    }
}
