using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SilentHysteria;

public class Card : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public CardData cardDataSO;

    public playerType _playerType = playerType.NULL;
    [SerializeField] public enum playerType { PLAYER1, PLAYER2, NULL };
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.CompareTag("Player"))
            _playerType = playerType.PLAYER1;

        else if (transform.parent.CompareTag("Player2"))
            _playerType = playerType.PLAYER2;

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

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //ViewManager.Instance.HideMenu();

        if (BattleSystem.Instance._attackState == BattleSystem.attackState.CHOOSECARD)
        {
            BattleSystem.Instance.playerCard = eventData.pointerClick.gameObject.GetComponent<Card>();
            BattleSystem.Instance._attackState = BattleSystem.attackState.CHOOSETARGET;
        }

        else if (BattleSystem.Instance._attackState == BattleSystem.attackState.CHOOSETARGET)
        {
            BattleSystem.Instance.targetCard = eventData.pointerClick.gameObject.GetComponent<Card>();
            BattleSystem.Instance._attackState = BattleSystem.attackState.IDLE;
            BattleSystem.Instance.canAttack = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //ViewManager.Instance.HideMenu();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //ViewManager.Instance.HideMenu();
    }
}
