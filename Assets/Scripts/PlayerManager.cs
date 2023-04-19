using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerCharacter;
    public Color skinColor;

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = playerCharacter.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        renderer.color = skinColor;
    }


}
