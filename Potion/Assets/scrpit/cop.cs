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

    public Animator animator;
    playerhealth playerHealth;
    bool playerIsDead = false;
    float direction = 1.0f;

    void Start()
    {
        currentHealth = maxHealth;
        if (player.TryGetComponent<playerhealth>(out var playerHealth))
        {
            this.playerHealth = playerHealth;
        }
    }


    void Update() //all the notes make boris turn like crazy
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;
        //direction.Normalize(); 
        //float angle = Mathf.Atan2(direction.y, direction.x ) * Mathf.Rad2Deg; 
        
        if (playerHealth.health <= 0 && !playerIsDead)
        {
            direction *= -1;
            playerIsDead = true;
        }

        if(distance< 5)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position * direction, speed* Time.deltaTime);
    animator.SetBool("walk", true);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle); 
        }
        else
{
    animator.SetBool("walk", false);
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
    animator.SetTrigger("dead");
    GetComponent<Collider2D>().enabled = false;
    this.enabled = false;

}
}
