﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : BaseState, IState
{
    const string ANIMATION_DEAD = "Dead";
    float timeToEnd = 0.3f;
    public HurtState(Entity gameObject) : base(gameObject){}
    public void OnEnter(){
        timeToEnd =  _entity.TimerOfBeeingHit;
        AnimatorExt.SetTrigger(ANIMATION_DEAD);
    }
    public void OnExit(){}
    public override void HandleInput(){}
    public override void ProcessGraphics(){}
    public override void ProcessPhysics(){
        timeToEnd -= Time.deltaTime;
        if( timeToEnd < 0 ){
             //LevelManager.Instance.ReloadLevel();
            _stateMachine.ChangeToState( new IdleState(_entity));
        }
    }
}
