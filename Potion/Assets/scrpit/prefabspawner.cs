using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PrefabSpawn : MonoBehaviour
{
    [SerializeField] private List<Potion> potions = new List<Potion>();

    //public GameObject Prefab { get => prefab; set => prefab = value; }

    void Start()
    {
        Resources.Load<GameObject>("potionfiller");

        //.sprite = null;
        

    }

    private void OnEnable()
    {
        Randomize();
    }


    void Update()
    {

    }

    public Potion Randomize()
    {
        Potion potion = potions[Random.Range(0, potions.Count)];
        potions.Remove(potion);
        return potion;
    }
}
