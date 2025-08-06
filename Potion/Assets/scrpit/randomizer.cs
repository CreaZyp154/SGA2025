using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class randomizerPotion 
{
    string[] potions = { "Word", "Pretty", "Hyper", "Amanita", "Hero", "Pocket" };

    List<string> currentPotions;

    public randomizerPotion()
    {
        currentPotions = new List<string>();
        foreach (var potion in potions) { 
            currentPotions.Add(potion);
        }
    }

    public string Randomize()
    {
        string potion = currentPotions[Random.Range(0, currentPotions.Count)];
        currentPotions.Remove(potion);
        return potion;
    }
}
