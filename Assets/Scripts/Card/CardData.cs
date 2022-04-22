using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card DataSO")]

public class CardData : ScriptableObject
{
    [Header("Card Parameter")]
    public cardType _cardType = cardType.MONSTER;
    [SerializeField] public enum cardType { MONSTER, TRAP, SPELL };

    public string cardName;
    public int attackValue;
    public int defendValue;
    public Sprite image;
}
