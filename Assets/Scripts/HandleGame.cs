using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HandleGame : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI coinText;
    void Update()
    {
        if (coins < 0)
        {
            coins = 0;
        }

        coinText.SetText(coins.ToString());
    }
}
