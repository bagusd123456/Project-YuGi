using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    public static TurnManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Turn Parameter")]
    public turnState _turnState = turnState.PLAYERTURN;
    [SerializeField] public enum turnState { PLAYERTURN, ENEMYTURN };

    public phaseState _phaseState = phaseState.BUSY;
    [SerializeField] public enum phaseState {BUSY, DRAWPHASE, MAINPHASE, ENDPHASE };

    public int turnIndex = 0;
    public int phaseIndex = 0;

    public TextMeshProUGUI currentTurnText;
    public TextMeshProUGUI currentPhaseText;
    // Start is called before the first frame update
    void Start()
    {
        SetTurn(0);
        SetPhase(0);
    }

    public void NextTurn()
    {
        if (turnIndex < 1)
        {
            turnIndex++;
            SetTurn(turnIndex);
        }
        else if (turnIndex >= 1)
        {
            turnIndex = 0;
            SetTurn(turnIndex);
        }
    }

    public void NextPhase()
    {
        if(phaseIndex < 2)
        {
            phaseIndex++;
            SetPhase(phaseIndex);
        }
        else if(phaseIndex >= 2)
        {
            phaseIndex = 0;
            SetPhase(phaseIndex);
            NextTurn();
        }
    }

    public void SetTurn(int number)
    {
        if(number == 0)
        {
            _turnState = turnState.PLAYERTURN;
            currentTurnText.text = "PLAYER TURN";
        }
        else if(number == 1)
        {
            _turnState = turnState.ENEMYTURN;
            currentTurnText.text = "ENEMY TURN";
        }
    }

    public void SetPhase(int number)
    {
        
        if (number == 0)
        {
            _phaseState = phaseState.DRAWPHASE;
            currentPhaseText.text = "DRAW PHASE";
        }
        else if (number == 1)
        {
            _phaseState = phaseState.MAINPHASE;
            currentPhaseText.text = "MAIN PHASE";
        }
        else if (number == 2)
        {
            _phaseState = phaseState.ENDPHASE;
            currentPhaseText.text = "END PHASE";
        }
        else if (number == 3)
        {
            _phaseState = phaseState.BUSY;
            currentPhaseText.text = "BUSY";
        }
    }
}
