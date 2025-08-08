using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PrefabSpawn : MonoBehaviour
{
    [SerializeField] private List<Potion> potions = new List<Potion>();
    [SerializeField] private Randomizer randomizer;

    //public GameObject Prefab { get => prefab; set => prefab = value; }

    void Start()
    {
        Resources.Load<GameObject>("potionfiller");

        //.sprite = null;
        

    }

    private void OnEnable()
    {
        randomizer = new Randomizer();
    }


    void Update()
    {

    }
}
