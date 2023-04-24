using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterCreation : MonoBehaviour
{
    public GameObject playerCharacter;
    public FlexibleColorPicker fcp;
    public static Color playerSkinColor = new Color(1.0f,1.0f,1.0f,1.0f);
    public static int playerBodyType = 0;
    public void RunGame()
    {
        playerBodyType = playerCharacter.GetComponent<PlayerPreviewManager>().bodyType;
        playerSkinColor = fcp.color;
        SceneManager.LoadScene("default");
    }

    public void HandleDropDown(int val)
    {
        if (val == 0)
        {
            playerCharacter.GetComponent<PlayerPreviewManager>().bodyType = 0;
        }
        else
        {
            playerCharacter.GetComponent<PlayerPreviewManager>().bodyType = 1; 
        }
    }

    public void RotatePreview()
    {
        playerCharacter.GetComponent<PlayerPreviewManager>().previewImage += 1;
    }

    private void Update()
    {
        playerCharacter.GetComponent<PlayerPreviewManager>().skinColor = fcp.color;
    }
}
