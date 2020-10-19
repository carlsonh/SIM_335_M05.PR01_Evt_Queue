using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EventPublisher : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {//Cannon
            EventBus.TriggerEvent("Shoot");
        }


        /// <summary>
        /// Event Queue'd
        /// </summary>
        /// <returns></returns>
        if (Input.GetKey("l"))
        {//Rocket
            EventBus.TriggerEvent("RackRocket");
        }
        if (Input.GetKeyUp("l"))
        {//Rocket
            EventBus.TriggerEvent("RocketBurstLaunch");
        }

        if (Input.GetMouseButtonDown(0))
        {//Gun
            EventBus.TriggerEvent("FireGun");
        }
        if (Input.GetKeyDown("r"))
        {//Gun
            EventBus.TriggerEvent("Reload");
        }


        if (Input.GetKeyDown("f"))
        {//Bird
            EventBus.TriggerEvent("Flap");
        }


        if (Input.GetKeyDown("e"))
        {//Wolf
            EventBus.TriggerEvent("Eat");
        }
        if (Input.GetKeyDown("s"))
        {//Wolf
            EventBus.TriggerEvent("Sleep");
        }
    }
}
