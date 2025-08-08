using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;

public class triggiepo : MonoBehaviour
{
    [SerializeField] PotionManager manager;
    public Canvas pot;
    RandomizerPotion randomizer;

     

    void OnTriggerEnter2D(Collider2D other)
    {
        pot.enabled = true;
        randomizer = new RandomizerPotion(manager);

        Potion potion = randomizer.Randomize();

    }

    void OnTriggerExit2D(Collider2D other)
    {
        pot.enabled = false; 
    }
}