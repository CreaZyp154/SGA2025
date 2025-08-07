using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics; 


public class playercombat : MonoBehaviour
{

    public Transform attackPoint; 
    public float attackRange = 0.5f; 
    public LayerMask enemyLayers; 
    public int attackDamage = 40;

    public Animator animator;

    private Stopwatch stopwatch;
    private long miliseconds = 0;

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            miliseconds = stopwatch.ElapsedMilliseconds;

            if (miliseconds > 2000)
            {
                Attack();
                stopwatch.Stop();
                stopwatch.Restart();
                miliseconds = 0;
                UnityEngine.Debug.Log("Attack");

            }


        }
        
    }



    void Attack()
    {
        animator.SetTrigger("Attack"); 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<cop>().TakeDamage(attackDamage);  
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint== null)
        {
            return;
        }
            

        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    }





}
