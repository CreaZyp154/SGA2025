using UnityEngine;
using UnityEngine.SceneManagement; 

public class wonner : MonoBehaviour
{
    public string win; 

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("win"); 
    }
}
