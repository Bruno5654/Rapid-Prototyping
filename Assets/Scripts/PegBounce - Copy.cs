using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegBounce : MonoBehaviour
{
    public float bounceScale = 1500.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            Vector3 playerPos = playerController.transform.position;
            Vector3 pegPos = transform.position;

            Vector3 towardPlayer = playerPos - pegPos;
            towardPlayer.Normalize();

            playerController.RB.AddForce(towardPlayer * 1500.0f, ForceMode.Force);

        }
    }
}
