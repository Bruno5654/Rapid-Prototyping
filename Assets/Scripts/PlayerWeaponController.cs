using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerWeaponController : MonoBehaviour
{
   
    public int weaponDamage;
    public int weaponID;
    
    public GameObject meleeObject;
    public GameObject _projectile;

    private float weaponCooldown;
    private int weaponType;
    private int weaponSpeed;
    private bool isSwinging;
    private void LaunchProjectile(int m_type, float m_speed)
    {
        GameObject bullet = Instantiate(_projectile, transform.position, Quaternion.identity);

        Vector3 mousePosition = GetComponent<TopDownCharacterController>().worldMousePos;

        switch (m_type)
        {
            case 1:
                bullet.GetComponent<Rigidbody2D>().velocity = (mousePosition - transform.position).normalized * m_speed;
                break;
            default:
                bullet.GetComponent<Rigidbody2D>().velocity = (mousePosition - transform.position).normalized * m_speed;
                break;
        }  
    }

    private void Awake()
    {
        meleeObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        meleeObject.transform.position = transform.position;
        //Check weapon stats are correct.
        switch (weaponID)
        {
            default: //Basic projectile.
                weaponDamage = 1;
                weaponSpeed = 1;
                weaponType = 2;
                break;
            case 1: //Basic projectile.
                weaponDamage = 1;
                weaponSpeed = 1;
                weaponType = 2;
                break;
            case 2: //Basic melee.
                weaponDamage = 1;
                weaponSpeed = 1;
                weaponType = 1;
                break;
        }
    }

    IEnumerator SwingSword()
    {
        Vector3 mousePosition = GetComponent<TopDownCharacterController>().worldMousePos;
        GetComponent<TopDownCharacterController>().canMove = false;
        isSwinging = true;
        meleeObject.SetActive(true);
        meleeObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
        yield return new WaitForSeconds(1f);
        meleeObject.SetActive(false);
        GetComponent<TopDownCharacterController>().canMove = true;
        yield return new WaitForSeconds(weaponSpeed);
        isSwinging = false;
    }
    public void Attack()
    {
        if(weaponCooldown <= Time.time)
        {
            weaponCooldown = Time.time + weaponSpeed;
            switch (weaponType)
            {
                default:
                    break;
                case 1:
                    if(!isSwinging)
                    {
                        StartCoroutine(SwingSword());
                    }
                    break;
                case 2:
                    LaunchProjectile(1, 45.0f);
                    break;
            }
        }
        
    }
}



