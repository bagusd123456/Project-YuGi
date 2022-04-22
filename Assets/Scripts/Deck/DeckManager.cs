using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // Just for Debugging
    [SerializeField] private CardData[] listCardData;
    private int currentIndex;

    // Current Deck Data
    private Dictionary<string, List<CardData>> _currentCardDeck = new Dictionary<string, List<CardData>>(){{"Player", new List<CardData>()}, {"Enemy", new List<CardData>()}};

    // Update is called once per frame
    void Update()
    {
        //Debugging Script
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddCard("Player",listCardData[currentIndex]);
            currentIndex++;
            if (currentIndex == listCardData.Length) currentIndex = 0;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PrintingAllDeckData();
        }
    }
    
    public void AddCard(string characterType, CardData cardToAdd)
    {
        if (!_currentCardDeck.ContainsKey(characterType)) return;
        
        _currentCardDeck[characterType].Add(cardToAdd);
    }

    public CardData[] LoadCard(string nameCharacterType)
    {
        return _currentCardDeck[nameCharacterType].ToArray();
    }
    
    
    // Just For Debugging Purpose
    public void PrintingAllDeckData()
    {
        for (int i = 0; i < _currentCardDeck.Count; i++)
        {
            for (int j = 0; j < _currentCardDeck.ElementAt(i).Value.Count; j++)
            {
                Debug.Log(_currentCardDeck.ElementAt(i).Value[j].cardName);
            }
        }
    }
}
