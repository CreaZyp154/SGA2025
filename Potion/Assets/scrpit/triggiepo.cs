using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;

public class triggiepo : MonoBehaviour
{
    [SerializeField] PotionManager manager;
    public GameObject pot;
     

    void OnTriggerEnter2D(Collider2D other)
    {
        pot.SetActive(true);
        Destroy(this);
    }

}