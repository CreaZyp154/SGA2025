using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private List<Potion> potionList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            potionList[0].Apply(player);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            player.GetComponent<player>().ResetEffects();
        }
        #endif
    }
}
