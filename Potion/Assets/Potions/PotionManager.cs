using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PotionManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Volume globalVolume;
    [SerializeField] private List<Potion> potionList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //FullscreenEffect fullscreenEffect = ScriptableObject.CreateInstance<FullscreenEffect>();
    }


    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            potionList[0].Apply(player, globalVolume);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            potionList[0].ChangeEffect(Modifier.Reset, 0, player, true);
            potionList[0].ResetVisuals(globalVolume);
        }
        #endif
    }
}
