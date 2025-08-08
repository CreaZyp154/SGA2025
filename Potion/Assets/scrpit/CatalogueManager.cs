using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatalogueManager : MonoBehaviour
{

    [SerializeField] private PotionList PL;
    [SerializeField] private GameObject potionPanel;
    [SerializeField] private GameObject card;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(Potion potion in PL.potionList)
        {
            GameObject currentCard = Instantiate(card, potionPanel.transform);

            Transform name = currentCard.transform.Find("Title");
            name.GetComponent<TextMeshProUGUI>().text = potion.potionName;
            Transform image = currentCard.transform.Find("Image");
            image.GetComponent<Image>().sprite = potion.image;
            Transform description = currentCard.transform.Find("Description");
            description.GetComponent<TextMeshProUGUI>().text = potion.description;
            Transform potionDesc = currentCard.transform.Find("Effect Description");
            potionDesc.GetComponent<TextMeshProUGUI>().text = potion.effectDescription;

            currentCard.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
