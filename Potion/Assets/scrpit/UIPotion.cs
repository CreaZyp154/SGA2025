using UnityEngine;
using UnityEngine.UI;

public class UIPotion : MonoBehaviour
{
    public Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Setup(Potion potion)
    {
        image.sprite = potion.image;
    }
}
