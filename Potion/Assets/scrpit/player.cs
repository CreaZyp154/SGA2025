using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D rb; 
    private Vector2 movementDirection; 

    private bool canDash = true; 
    private bool isDashing; 
    private float dashingPower = 24f; 
    private float dashingTime = 0.2f; 
    private float dashingCooldown = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }
        
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate() 
    {
        if (isDashing)
        {
            return;
        }
        
        rb.linearVelocity = movementDirection * movementSpeed; 
    }

    private IEnumerator Dash()
    {
        canDash = false; 
        isDashing = true;
        
        
        Vector2 dashDirection = movementDirection.normalized;
        if (dashDirection == Vector2.zero)
        {
            
            dashDirection = Vector2.right;
        }
        
        rb.linearVelocity = dashDirection * dashingPower;
        tr.emitting = true; 
        
        yield return new WaitForSeconds(dashingTime);
        
        tr.emitting = false; 
        isDashing = false; 
        
        yield return new WaitForSeconds(dashingCooldown); 
        canDash = true; 
    }
}