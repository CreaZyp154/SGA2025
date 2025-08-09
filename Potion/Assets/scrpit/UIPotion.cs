using UnityEngine;
using UnityEngine.UI;

public class UIPotion : MonoBehaviour
{

    public Potion activePotion;
    public PotionManager manager;

    public void Setup(Potion potion)
    {
        Image image = GetComponent<Image>();
        image.sprite = potion.image;
        activePotion = potion;
    }

    public void ApplyPotion()
    {
        manager.Apply(activePotion);
        transform.parent.gameObject.SetActive(false);
    }
}
