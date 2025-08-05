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

    void Start()
    {
        maxHealth = health; 
    }

    
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1); 

        if(health <= 0)
        {
            SceneManager.LoadScene(respawn); 

        }
    }
}
