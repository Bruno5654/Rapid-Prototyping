using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquippableWeapon : MonoBehaviour
{
    public int weaponDamage;
    public int weaponSpeed;
    public int weaponType;

    public TextMeshProUGUI equipText;
    public GameObject player;

    public Sprite weaponType1; //Sword
    public Sprite weaponType2; //Bow

    private bool playerIsOver;
    private Vector3 startingPosition;
    private Vector3 hiddenPosition;
    private float equipCooldown;

    // Start is called before the first frame update
    void Start()
    {
        switch (weaponType)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = weaponType1;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = weaponType2;
                break;
        }
       
        startingPosition = transform.position;
        hiddenPosition.y = 69420.0f;

    }

    private void Update()
    {
        //Check if needs to be equipped.
        if (player.GetComponent<TopDownCharacterController>().ePressed && playerIsOver && equipCooldown <= Time.time)
        {
            if (player.GetComponent<PlayerWeaponController>().currentWeapon != null)
            {
                player.GetComponent<PlayerWeaponController>().currentWeapon.transform.position = player.transform.position;
                player.GetComponent<PlayerWeaponController>().currentWeapon.GetComponent<EquippableWeapon>().equipCooldown = Time.time + 0.5f;
            }
            
            player.GetComponent<PlayerWeaponController>().currentWeapon = gameObject;
            transform.position = hiddenPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            equipText.enabled = true;
            equipText.gameObject.SetActive(true);
            playerIsOver = true;
    
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            equipText.enabled = false;
            equipText.gameObject.SetActive(false);
            playerIsOver = false;
        }
    }  
}
