using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardData cardDataSO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = cardDataSO.cardName;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cardDataSO.attackValue.ToString();
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardDataSO.defendValue.ToString();
        transform.GetChild(3).GetComponent<Image>().sprite = cardDataSO.image;
        if (cardDataSO._cardType == CardData.cardType.MONSTER)
        {
            gameObject.GetComponent<Image>().color = new Color32(148, 235, 0, 255);
        }
        else if (cardDataSO._cardType == CardData.cardType.TRAP)
        {
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            gameObject.GetComponent<Image>().color = new Color32(214, 0, 83, 255);
        }
        else if (cardDataSO._cardType == CardData.cardType.SPELL)
        {
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            gameObject.GetComponent<Image>().color = new Color32(0, 204, 255, 255);
        }
    }

    private void OnValidate()
    {
        
    }
}
