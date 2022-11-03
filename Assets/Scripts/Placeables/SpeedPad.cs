using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPad : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //collider.GetComponent<PlayerController>().RB.AddForce(Vector3.forward * (SpeedIncrease * SpeedIncreaseMod), ForceMode.Force);
            collider.GetComponent<PlayerController>().isSpeedBoost = true;
        }

    }
}
