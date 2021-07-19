﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    private float duration  = 0.0f;
    [SerializeField] private float magnitude = 10f;
    Vector3 initialPosition;

    public void TriggerShake( float shakeDuration) {
        duration        = shakeDuration;
        initialPosition = transform.position; 
    }

    void Awake(){
        Instance = transform.GetComponent<CameraShake>();
        initialPosition = transform.position; 
    }

    void Update(){
        if (duration > 0){
            if( Time.timeScale < 1 ) return;

            transform.localPosition = initialPosition + Random.insideUnitSphere * magnitude;
            
            Vector3 shakeValue = Random.insideUnitSphere * magnitude;
            shakeValue.z       = 0;
            transform.localPosition = initialPosition + shakeValue;
            
            duration -= Time.deltaTime;
        }else{
            duration = 0f;
        }
    }
}
