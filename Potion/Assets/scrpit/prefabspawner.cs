using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PrefabSpawn : MonoBehaviour
{
    [SerializeField] private PotionList PotionListSO;
    [SerializeField] private List<Potion> tmpPotionList;
    [SerializeField] private Potion[] currentPotions = new Potion[3];

    [SerializeField] private GameObject Potion1;
    [SerializeField] private GameObject Potion2;
    [SerializeField] private GameObject Potion3;


    //public GameObject Prefab { get => prefab; set => prefab = value; }

    private void OnEnable()
    {
        tmpPotionList = new List<Potion>(PotionListSO.potionList);
        for (int i = 0; i < currentPotions.Length; i++)
        {
            currentPotions[i] = Randomize();
        }

        Potion1.GetComponent<UIPotion>().Setup(currentPotions[0]);
        Potion2.GetComponent<UIPotion>().Setup(currentPotions[1]);
        Potion3.GetComponent<UIPotion>().Setup(currentPotions[2]);

    }

    private void OnDisable()
    {
        tmpPotionList.Clear();
        currentPotions = null;
    }

    public Potion Randomize()
    {
        Potion potion = tmpPotionList[Random.Range(0, tmpPotionList.Count)];
        tmpPotionList.Remove(potion);
        return potion;
    }
}
