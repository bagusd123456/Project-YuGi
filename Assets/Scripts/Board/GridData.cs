using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    [Header("Board Parameter")]
    public gridType _gridType = gridType.MONSTER;
    public playerType _playerType = playerType.NULL;
    public bool isOccupied = false;
    [SerializeField] public enum gridType { MONSTER, TRAPSPELL, NULL };
    [SerializeField] public enum playerType { PLAYER1, PLAYER2, NULL };
    private void FixedUpdate()
    {
        if (GetComponentInChildren<Card>() != null)
            isOccupied = true;
        else
            isOccupied = false;
    }
}
