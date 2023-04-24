using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerPreviewManager : MonoBehaviour
{
    public GameObject playerCharacter;
    public Color skinColor;
    public int bodyType;
    public int previewImage;
    public Sprite bt0_0, bt0_1, bt0_2, bt0_3, bt1_0, bt1_1, bt1_2, bt1_3;

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Update color previews.
        renderer.color = skinColor;

        //Update body previews.
        if (previewImage > 3)
        {
            previewImage = 0;
        }

        if(bodyType == 0)
        {
            switch(previewImage)
            {
                case 0:
                    renderer.sprite = bt0_0;
                    break;
                case 1:
                    renderer.sprite = bt0_1;
                    break;
                case 2:
                    renderer.sprite = bt0_2;
                    break;
                case 3:
                    renderer.sprite = bt0_3;
                    break;
            }
        }
        else
        {
            switch (previewImage)
            {
                case 0:
                    renderer.sprite = bt1_0;
                    break;
                case 1:
                    renderer.sprite = bt1_1;
                    break;
                case 2:
                    renderer.sprite = bt1_2;
                    break;
                case 3:
                    renderer.sprite = bt1_3;
                    break;
            }
        }
        
    }


}
