using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy_damage : MonoBehaviour
{
    
    public float damage;
    private bool isTouching;  
    private float lastHitTime = 0;  

    void Start()
    {
        
    }

   
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastHitTime >= 2f){
                GameObject player = other.gameObject;
                if (!player.GetComponent<player>().invincible)
                {
                    other.gameObject.GetComponent<playerhealth>().health -= damage;
                }

                lastHitTime = Time.time;
            }
        }

        
    }

}   