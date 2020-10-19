using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private bool m_IsQuitting;
    public int ammoCount = 20;
    private void OnEnable()
    {
        EventBus.StartListening("FireGun", FireGun);
        EventBus.StartListening("Reload", Reload);
    }

    private void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("FireGun", FireGun);
            EventBus.StopListening("Reload", Reload);
        }
    }

    void FireGun()
    {
        if (ammoCount > 0)
        {
            Debug.Log("Bang!");
            ammoCount--;
        }
        else
        {
            Debug.Log("Click");
        }
    }

    void Reload()
    {
        Debug.Log("Reloading!");
        ammoCount = 20;
    }

}
