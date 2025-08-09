using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Rendering;
using JetBrains.Annotations;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public enum Modifier
{
    Reset,
    InvertControls,
    Speed,
    Scale,
    Opacity,
    Regen,
    MaxHealth,
    Invincibility
}

[System.Serializable]
public enum VisualEffect
{
    None,
    Reset,
    Green,
    Monochrome
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
    public Sprite image;

    private ColorAdjustments colorAdjustments;

    public List<Modifiers> modifiers = new List<Modifiers>();

    public VisualEffect visualEffect;

    public void Apply(GameObject user, Volume globalVolume)
    {
        ChangeVisualEffect(visualEffect, globalVolume);
        foreach(Modifiers modifier in modifiers)
        {
            ChangeEffect(modifier.effect, modifier.value, user, true);
        }
    }

    public void Remove(GameObject user, Volume globalVolume)
    {
        ChangeVisualEffect(VisualEffect.Reset, globalVolume);
        foreach (Modifiers modifier in modifiers)
        {
            ChangeEffect(modifier.effect, modifier.value, user, false);
        }
    }

    public void ResetVisuals(Volume globalVolume)
    {
        ChangeVisualEffect(VisualEffect.Reset, globalVolume);
    }

    public void ChangeEffect(Modifier effect, float value, GameObject user, bool activate)
    {
        player player = user.GetComponent<player>();
        playerhealth health = user.GetComponent<playerhealth>();
        switch (effect)
        {
            case Modifier.Reset:
                player.ResetEffects();
                ChangeEffect(Modifier.Opacity, 1, user, true);
                break;
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
            case Modifier.Opacity:
                Color color = player.GetComponent<SpriteRenderer>().color;
                color.a = activate ? value : 1;
                player.GetComponent<SpriteRenderer>().color = color;
                break;
            case Modifier.Regen:
                health.health = value > 0 ? health.maxHealth : 0;
                break;
            case Modifier.MaxHealth:
                health.maxHealth += activate ? value : -value;
                health.health = health.maxHealth;
                break;
            case Modifier.Invincibility:
                //invis code
                PotionManager manager = FindFirstObjectByType<PotionManager>();
                player.invincible = activate;
                manager.RemoveAfter(this, user, value);
                break;
        }
    }

    void ChangeVisualEffect(VisualEffect effect, Volume globalVolume)
    {
        ColorAdjustments tmp;
        if (globalVolume.profile.TryGet(out tmp))
        {
            colorAdjustments = tmp;
        }
        switch (effect)
        {
            case VisualEffect.Reset:
                //On avait just pas fait exactement comme il faut.
                //En faisant new on modifiait une struct temporaire

                /*La sollution c'est ça -> */ colorAdjustments.colorFilter.overrideState = true; //On annonce qu'on va override le volume
                colorAdjustments.colorFilter.value = Color.white; //ensuite on change directement la valeur
                colorAdjustments.saturation.overrideState = true;
                colorAdjustments.saturation.value = 0;
                break;
            case VisualEffect.Green:
                ChangeVisualEffect(VisualEffect.Reset, globalVolume);
                colorAdjustments.colorFilter.overrideState = true;
                colorAdjustments.colorFilter.value = Color.green;
                break;
            case VisualEffect.Monochrome:
                ChangeVisualEffect(VisualEffect.Reset, globalVolume);
                colorAdjustments.saturation.overrideState = true;
                colorAdjustments.saturation.value = -100;
                break;
        }
        
    }
}