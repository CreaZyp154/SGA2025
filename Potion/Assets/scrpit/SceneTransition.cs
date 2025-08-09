using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneTransition : MonoBehaviour
{
    public string first;
    public string menu;
    public Canvas death;
    public Canvas pause;
    public Rigidbody2D rb;
    public Canvas Catalogue;
    public Canvas mainmenu; 


    public void Reload()
    {
        SceneManager.LoadScene(first);
    }

    public void Men()
    {
        SceneManager.LoadScene(menu);
    }

    public void Close()
    {
        death.enabled = false; 
    }

    public void closagain()
    {
        pause.enabled = false;
        rb.constraints = RigidbodyConstraints2D.None;
    }

    public void dictionnary()
    {
        mainmenu.enabled = false;
        Catalogue.enabled = true; 
    }

    public void back()
    {
        Catalogue.enabled = false;
        mainmenu.enabled = true; 
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("quit"); 
    }

}


