using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneTransition : MonoBehaviour
{
    public string first;


    public void NextScene()
    {
        SceneManager.LoadScene(first);
    }
}


