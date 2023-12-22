using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemacineShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineCam;
    private float shakeTimer;
    public static CinemacineShake instance{get;private set;}
    private void Awake()
    {
        if(instance == null)
        {
            instance=this;
        }
        cinemachineCam=GetComponent<CinemachineVirtualCamera>();
    }
    public void ShakeCamera(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachinePerlin=cinemachineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachinePerlin.m_AmplitudeGain=intensity;
        shakeTimer=time;
    }
    private void Update() {
        {
            if(shakeTimer>0)
            {
                shakeTimer-=Time.deltaTime;
                if(shakeTimer<=0f)
                {
                    CinemachineBasicMultiChannelPerlin cinemachinePerlin=cinemachineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    cinemachinePerlin.m_AmplitudeGain=0;
                }
            }
        }
    }
}
