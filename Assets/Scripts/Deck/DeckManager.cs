using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private static DeckManager instance;
    public static DeckManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Just for Debugging
    [SerializeField] private CardData[] listCardData;
    public int currentIndex;

    // Current Deck Data
    public List<CardData> playerDeck;
    public List<CardData> enemyDeck;
    public GameObject cardPrefab;

    //Current Card on Hand
    public Card[] playerHand;
    public GameObject playerGO;

    public Card[] enemyHand;
    public GameObject enemyGO;

    void Start()
    {
        for (int i = playerDeck.Count; i <= 40; i++)
        {
            AddCard(playerDeck);
        }

        PopulatePlayerHand();

        for (int i = enemyDeck.Count; i <= 40; i++)
        {
            AddCard(enemyDeck);
        }

        PopulateEnemyHand();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debugging Script
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadCard(playerDeck, playerGO);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            AddCard(playerDeck);
        }
    }

    public void PopulatePlayerHand()
    {
        // Automatically Load Card to Hand if Value under 5
        for (int i = playerHand.Length; i < 5; i++)
        {
            LoadCard(playerDeck, playerGO);
        }

        // Automatically Add Card in Child to playerHandArray
        playerHand = playerGO.GetComponentsInChildren<Card>();
    }

    public void PopulateEnemyHand()
    {
        // Automatically Load Card to Hand if Value under 5
        for (int i = enemyHand.Length; i < 5; i++)
        {
            LoadCard(enemyDeck, enemyGO);
        }

        // Automatically Add Card in Child to playerHandArray
        enemyHand = enemyGO.GetComponentsInChildren<Card>();
    }

    void LoadCard(List<CardData> characterDeck, GameObject targetGO)
    {
        //If Card on Deck is not 0, get random card from deck to Hand
        if (characterDeck.Count > 0)
        {
            GameObject card = Instantiate(cardPrefab, targetGO.transform);
            currentIndex = UnityEngine.Random.Range(0, characterDeck.Count);
            card.GetComponent<Card>().cardDataSO = characterDeck[currentIndex];
            GetIndex();

            if (characterDeck.Count > 1)
            {
                //playerHand.Add(card.GetComponent<Card>().cardDataSO = characterDeck[currentIndex]);
                characterDeck.RemoveAt(currentIndex); //Get Card with the Index number
            }
            else if (characterDeck.Count == 1)
            {
                characterDeck.Clear(); //Clear deck if zero
            }
        }
    }

    void AddCard(List<CardData> characterDeck)
    {
        //GameObject card = Instantiate(cardPrefab, gameObject.transform);
        //card.GetComponent<Card>().cardDataSO = listCardData[UnityEngine.Random.Range(0, 3)];
        //characterDeck.Add(card.GetComponent<Card>().cardDataSO);
        if (characterDeck.Count < 40)
        {
            characterDeck.Add(listCardData[UnityEngine.Random.Range(0, 3)]);
        }
    }

    public void GetIndex()
    {
        foreach (var item in playerHand)
        {
            item.GetComponent<DragAndDrop>().objectIndex = item.transform.GetSiblingIndex();
        }
    }
}
