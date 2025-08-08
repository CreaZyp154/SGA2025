using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class playerhealth : MonoBehaviour
{
    public float health; 
    public float maxHealth; 
    public Image healthBar; 
    public int respawn; 
    public Animator animator;
    public Rigidbody2D rb;
    public Canvas ded;
    public Canvas helth; 

    void Start()
    {
        maxHealth = health;
       
    }

    
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1); 

        if(health <= 0)
        {
            animator.SetTrigger("dead");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            ded.enabled = true;
            helth.enabled = false; 
            
            this.enabled = false;
             

        }
    }
}
