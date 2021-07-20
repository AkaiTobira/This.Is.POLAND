using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState, IState
{
    bool accelerateJumpforce = true;
    float elapsedTime = 0;

    Rigidbody2D _playerRB;

    public JumpState(Entity gameObject) : base(gameObject){}
    public void OnEnter(){
        Physic?.Jump();
        accelerateJumpforce = true;
        _playerRB = Physic?.GetComponent<Rigidbody2D>();

        AnimatorExt?.SetBool("Jumping", true);
        AnimatorExt?.SetBool("OnGround", false);
    }

    public void OnExit()
    {
        AnimatorExt?.SetBool("OnGround", true);
        AnimatorExt?.SetBool("Jumping", false);
    }

    public override void HandleInput(){
        AnimatorExt.UpdateSide(Controll.GetHorizontalAxisSign());
        if ( accelerateJumpforce ){
            Physic.AddJumpForce();
            if( !Controll.isJumpHold() || elapsedTime >= _entity.JumpHoldTime){
                accelerateJumpforce = false;
            }
            elapsedTime = Mathf.Min(elapsedTime + Time.deltaTime, _entity.JumpHoldTime);
        }
    }

    public override void ProcessGraphics(){
        AnimatorExt.SetFloat("JumpDirection", Mathf.Sign(_playerRB.velocity.y));
        AnimatorExt.SetBool("Moving", Controll.isLeftHold() || Controll.isRightHold());
        if( _playerRB.velocity.y > 0 ){
            AnimatorExt.SetBool("OnGround", false);
        }
    }
    
    public override void ProcessPhysics(){
        Physic.Move(Controll.GetHorizontalAxisSign());
        if( Physic.isOnGround( ) && !accelerateJumpforce){
            CameraShake.Instance.TriggerShake(0.1f);
            _stateMachine.ChangeToState( new IdleState(_entity));
        }
    }
}
