using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject gm;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gm.GetComponent<HandleGame>().coins -= 3;
            collision.transform.position = respawnPoint.position;
        }
    }
}
