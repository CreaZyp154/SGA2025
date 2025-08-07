using System;
using System.Collections;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Player stats")]
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D rb; 
    private Vector2 movementDirection;
    private Transform transform;

    public struct PlayerModifier
    {
        public float speed, scale;
        public void Init()
        {
            speed = 1f;
            scale = 1f;
        }
    }
    public PlayerModifier modifier = new PlayerModifier();

    private bool canDash = true; 
    private bool isDashing; 
    private float dashingPower = 24f; 
    private float dashingTime = 0.2f; 
    private float dashingCooldown = 1f;

    private float x; 
    private float y;

    float inputHorizontal; 
    float inputVertical;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetEffects();
        
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

        GetInput(); 

    }

    void FixedUpdate() 
    {
        if (isDashing)
        {
            return;
        }
        
        rb.linearVelocity = movementDirection * movementSpeed;

        rb.linearVelocity = new Vector3(x * movementSpeed, y * movementSpeed); 

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal == 0 && inputVertical == 0)
        {
            animator.SetBool("Walk", false);
        }

        if (inputHorizontal != 0)
        {
            rb.AddForce(new Vector2(inputHorizontal * movementSpeed, 0f));
            
        }
        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("Walk", true); 
        }
        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("Walk", true);
        }

        if (inputVertical != 0)
        {
            rb.AddForce(new Vector2(inputHorizontal * movementSpeed, 0f));
     
        }
        if (inputVertical > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("Walk", true);
        }
        if (inputVertical < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("Walk", true);
        }

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

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal"); 
        y = Input.GetAxisRaw("Vertical"); 
    }

    public void ResetEffects()
    {
        modifier.Init();
        ApplyScale();
    }

    public void ApplyScale()
    {
        Transform transform = GetComponent<Transform>();
        //transform.globalScale.Set(x = PlayerModifier.scale, y = PlayerModifier.scale);
        transform.localScale = new Vector3(modifier.scale, modifier.scale, 1);
    }
}