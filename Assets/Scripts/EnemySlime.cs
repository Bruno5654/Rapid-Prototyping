using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    Color slimeColor;
    Color oSlimeColor;
    public GameObject manager;
    public GameObject player;
    public float speed;
    public int hp;

    private bool isActive;
    
    
    void Start()
    {
        slimeColor.r = Random.Range(0.0f, 1.0f);
        slimeColor.g = Random.Range(0.0f, 1.0f);
        slimeColor.b = Random.Range(0.0f, 1.0f);
        slimeColor.a = 0.0f;
        oSlimeColor = slimeColor;
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "harmful" && isActive)
        {
            Knockback(player.GetComponent<PlayerWeaponController>().weaponKnockback);
            Flash();
            hp -= player.GetComponent<PlayerWeaponController>().weaponDamage;
        }

        if (collision.gameObject.tag == "Player" && isActive)
        {
            Knockback(1000f);
            player.GetComponent<TopDownCharacterController>().hp --;
            Debug.Log("Take Damage");
        }
    }

    private void FixedUpdate()
    {
        GetComponent<SpriteRenderer>().color = slimeColor;

        if (slimeColor.a < 0.8f)
        {
            slimeColor.a += 0.025f;
        }
        else
        {
            oSlimeColor.a = 0.8f;
            isActive = true;
        }

        //Chase Player
        if(isActive && player.GetComponent<TopDownCharacterController>().isDead == false)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }

    private void Flash()
    {
        slimeColor = Color.red;
        Invoke("FinishFlash",0.1f);
    }

    private void FinishFlash()
    {
        
        slimeColor = oSlimeColor;
    }

    private void Knockback(float knockbackForce)
    {
        Vector3 direction = (transform.position - player.transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce);
    }


    private void Update()
    {
        if(hp <= 0)
        {
            isActive = false;
            manager.GetComponent<EnemyController>().enemyCount--;
            player.GetComponent<TopDownCharacterController>().score += 10;
            Destroy(gameObject);

        }
    }
}
