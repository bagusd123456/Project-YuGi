using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public CardData[] cardDeck;
    public CardData[] deckArray;

    public int deckSize;
    public int cardId;

    public CardData cardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deckArray = GetComponentsInChildren<CardData>();
    }

    public void AddCard()
    {

    }

    public void DeleteCard()
    {

    }
}
