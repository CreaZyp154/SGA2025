using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cop : MonoBehaviour
{
    public GameObject player; 
    public float speed; 
    private float distance; 
    public int maxHealth; 
    int currentHealth; 
    
    void Start()
    {
        currentHealth = maxHealth; 
    }

    
    void Update() //all the notes make boris turn like crazy
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position; 
        //direction.Normalize(); 
        //float angle = Mathf.Atan2(direction.y, direction.x ) * Mathf.Rad2Deg; 
        

        if(distance < 5){
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); 
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle); 
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died !!!!!!"); 
        // animation de mort 
        GetComponent<Collider2D>(). enabled = false; 
        this.enabled = false; 

    }
}
