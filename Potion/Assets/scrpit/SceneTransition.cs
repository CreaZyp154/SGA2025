using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneTransition : MonoBehaviour
{
    public string first;
    public string menu;


    public void NextScene()
    {
        SceneManager.LoadScene(first);
        SceneManager.LoadScene(menu);
    }

    //public void  {
}


