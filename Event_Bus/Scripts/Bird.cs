using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool m_IsQuitting;
    private void OnEnable()
    {
        EventBus.StartListening("Flap", Flap);
    }

    private void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Flap", Flap);
        }
    }

    void Flap()
    {
        Debug.Log("Flap");
    }
}
