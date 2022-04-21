using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    [Header("Board Parameter")]
    public gridType _gridType = gridType.MONSTER;
    [SerializeField] public enum gridType { MONSTER, TRAPSPELL};
}
