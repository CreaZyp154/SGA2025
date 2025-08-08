using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Rendering;
using JetBrains.Annotations;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "Potions/Potion List")]
public class PotionList : ScriptableObject
{
    public List<Potion> potionList;
}