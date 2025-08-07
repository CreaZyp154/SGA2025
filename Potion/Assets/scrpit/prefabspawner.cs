using UnityEngine;
using UnityEngine.UI;

public class PrefabSpawn : MonoBehaviour
{
    [SerializeField] private Image[] image;

    //public GameObject Prefab { get => prefab; set => prefab = value; }

    void Start()
    {
        Resources.Load<GameObject>("potionfiller");

        image[0].sprite = null;
        

    }


    void Update()
    {

    }
}
