using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public enum Modifier
{
    InvertControls,
    Speed,
    Scale,
    Reset
}

[CreateAssetMenu(menuName = "Potions/New Potion")]
public class Potion : ScriptableObject
{
    [System.Serializable]
    public struct Modifiers
    {
        public Modifier effect;
        public float value;
    }

    public string potionName;
    [TextArea] public string description;
    public string effectDescription;
    public Texture2D image;

    public List<Modifiers> modifiers = new List<Modifiers>();

    public void Apply(GameObject user)
    {
        foreach(Modifiers modifier in modifiers)
        {
            ChangeEffect(modifier.effect, modifier.value, user, true);
        }
    }

    public void Remove(GameObject user)
    {
        foreach (Modifiers modifier in modifiers)
        {
            ChangeEffect(modifier.effect, modifier.value, user, false);
        }
    }

    void ChangeEffect(Modifier effect, float value, GameObject user, bool activate)
    {
        player player = user.GetComponent<player>();
        switch (effect)
        {
            case Modifier.InvertControls:
                player.modifier.speed = Math.Abs(player.modifier.speed) * (activate ? -1 : 1);
                break;
            case Modifier.Speed:
                player.modifier.speed += (activate ? value : -value);
                break;
            case Modifier.Scale:
                bool bigger = Random.Range(0,2) > 0;
                player.modifier.scale *= (bigger ? value : 1 / value);
                player.ApplyScale();
                break;
            case Modifier.Reset:
                player.ResetEffects();
                break;
        }
    }
}