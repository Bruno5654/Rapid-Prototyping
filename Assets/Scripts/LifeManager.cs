using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public GameObject player;
    public Image[] hearts;

    private int heartNum;

    // Update is called once per frame
    void Update()
    {
        heartNum = player.GetComponent<TopDownCharacterController>().hp;

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < heartNum)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
