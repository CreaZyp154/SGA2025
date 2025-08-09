using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PotionManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Volume globalVolume;
    [SerializeField] public PotionList PL;

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
            PL.potionList[0].Apply(player, globalVolume);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            PL.potionList[0].ChangeEffect(Modifier.Reset, 0, player, true);
            PL.potionList[0].ResetVisuals(globalVolume);
        }
        #endif
    }

    public void Apply(Potion potion)
    {
        potion.Apply(player, globalVolume);
    }

    public void RemoveAfter(Potion potion, GameObject user, float time)
    {
        StartCoroutine(PotionTimer(potion, user, time));
    }

    private IEnumerator PotionTimer(Potion potion, GameObject user, float time)
    {
        yield return new WaitForSeconds(time);
        potion.Remove(user, globalVolume);
    }
}
