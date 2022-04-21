using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    [Header("Card Parameter")]
    public cardType _cardType = cardType.MONSTER;
    [SerializeField] public enum cardType { MONSTER, TRAP, SPELL };
}
