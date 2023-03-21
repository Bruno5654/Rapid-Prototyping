using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    Vector2 floatY;
    float startY;
    public float floatStrength;
    void Start()
    {
        this.startY = this.transform.position.y;
    }

    void Update()
    { 
        transform.position = new Vector2(transform.position.x, startY + (Mathf.Sin(Time.time) * floatStrength));
    }
}
