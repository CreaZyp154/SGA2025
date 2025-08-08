using UnityEngine;
using System.Collections.Generic;


public class RandomizerPotion
{
    private PotionManager _manager;

    List<Potion> currentPotions = new List<Potion>();

    public RandomizerPotion(PotionManager manager)
    {
        _manager = manager;
        currentPotions = manager.potionList;
    }


}
