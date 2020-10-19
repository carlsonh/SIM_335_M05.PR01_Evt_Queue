using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private bool m_IsQuitting;
    private void OnEnable()
    {
        EventBus.StartListening("Eat", Eat);
        EventBus.StartListening("Sleep", Sleep);
    }

    private void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Eat", Eat);
            EventBus.StopListening("Sleep", Sleep);
        }
    }

    void Eat()
    {
        Debug.Log("Wolf gets some food");
    }

    void Sleep()
    {
        Debug.Log("Wolf takes a nap");
    }
}
