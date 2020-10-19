using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private bool m_IsQuitting;
    private bool m_IsLaunched = false;


    public float rackTime = 0.5f;
    private int rocketCount = 0;


    private float _triggerTime = 0f;

    private void OnEnable()
    {
        EventBus.StartListening("RackRocket", RackRocket);
        EventBus.StartListening("RocketBurstLaunch", RocketBurstLaunch);
        EventBus.StartListening("FireRocket", FireRocket);
    }

    private void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("RackRocket", RackRocket);
            EventBus.StopListening("RocketBurstLaunch", RocketBurstLaunch);
            EventBus.StopListening("FireRocket", FireRocket);
        }
    }



    void RackRocket()
    {
        if (Time.time >= _triggerTime + rackTime)
        {//Delay racking by rackTime
            _triggerTime = Time.time;
            rocketCount++;
            Debug.Log("Racked rocket: " + rocketCount + " loaded");
        }
    }

    void RocketBurstLaunch()
    {
        Debug.Log("Launching rocket swarm! " + rocketCount + " in burst");

        StartCoroutine(CallFireRocket(rocketCount));


        IEnumerator CallFireRocket(float _rocketCount)
        {
            for (int i = 0; i < _rocketCount; i++)
            {
                EventBus.TriggerEvent("FireRocket");
                yield return new WaitForSeconds(0.125f);
            }
        }

        rocketCount = 0;
    }


    void FireRocket()
    {
        Debug.Log("Launching Rocket!");
    }

}
