using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;

public class triggiepo : MonoBehaviour
{
    public Canvas pot;
    randomizerPotion randomizer;

     

    void OnTriggerEnter2D(Collider2D other)
    {
        pot.enabled = true;
        randomizer = new randomizerPotion();

        string potion = randomizer.Randomize();

    }

    void OnTriggerExit2D(Collider2D other)
    {
        pot.enabled = false; 
    }
}