using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishCharacterCreation : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("default");
    }
}
