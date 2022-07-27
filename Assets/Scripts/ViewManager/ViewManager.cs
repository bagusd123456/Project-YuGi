using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using SilentHysteria;

public class ViewManager : MonoBehaviour
{

    private static ViewManager instance;

    public static ViewManager Instance
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

    public RectTransform playerDeck;
    public RectTransform enemyDeck;
    public Vector3 defaultPos;
    public Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = playerDeck.transform.position;
    }

    public void CheckPhase()
    {
        if (TurnManager.Instance._phaseState == TurnManager.phaseState.DRAWPHASE)
        {
            DeckManager.Instance.PopulatePlayerHand();
            ShowMenu(playerDeck);
        }
            
        else if (TurnManager.Instance._phaseState == TurnManager.phaseState.MAINPHASE)
        {
            BattleSystem.Instance._attackState = BattleSystem.attackState.CHOOSECARD;
            HideMenu(playerDeck);
        }
            
        else if (TurnManager.Instance._phaseState == TurnManager.phaseState.ENDPHASE)
        {
            BattleSystem.Instance.Attack();
            HideMenu(playerDeck);
        }
            
    }

    [ContextMenu("Hide Menu")]
    public void HideMenu(RectTransform targetDeck)
    {
        targetDeck.transform.DOMove(new Vector3(defaultPos.x, targetPos.y, defaultPos.z), .35f);
    }

    [ContextMenu("Show Menu")]
    public void ShowMenu(RectTransform targetDeck)
    {
        targetDeck.transform.DOMove(new Vector3(defaultPos.x, defaultPos.y, defaultPos.z), .35f);
    }
}
