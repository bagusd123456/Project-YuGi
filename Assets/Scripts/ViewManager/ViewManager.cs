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
    public Vector3 defaultPlayerPos;
    public Vector3 targetPlayerPos;
    public Vector3 defaultEnemyPos;
    public Vector3 targetEnemyPos;

    // Start is called before the first frame update
    void Start()
    {
        defaultPlayerPos = playerDeck.transform.position;
        defaultEnemyPos = enemyDeck.transform.position;
        enemyDeck.transform.position = targetEnemyPos;
    }

    public void CheckPhase()
    {
        if (TurnManager.Instance._phaseState == TurnManager.phaseState.DRAWPHASE)
        {
            if(TurnManager.Instance._turnState == TurnManager.turnState.PLAYERTURN)
            {
                ShowPlayerMenu();
                HideEnemyMenu();
            }

            else if(TurnManager.Instance._turnState == TurnManager.turnState.ENEMYTURN)
            {
                ShowEnemyMenu();
                HidePlayerMenu();
            }
            
        }
            
        else if (TurnManager.Instance._phaseState == TurnManager.phaseState.MAINPHASE)
        {
            BattleSystem.Instance._attackState = BattleSystem.attackState.CHOOSECARD;
            HidePlayerMenu();
            HideEnemyMenu();
        }
            
        else if (TurnManager.Instance._phaseState == TurnManager.phaseState.ENDPHASE)
        {
            BattleSystem.Instance.Attack();
            DeckManager.Instance.PopulatePlayerHand();
            DeckManager.Instance.PopulateEnemyHand();
        }
            
    }

    [ContextMenu("Hide Menu")]
    public void HidePlayerMenu()
    {
        playerDeck.transform.DOMove(new Vector3(defaultPlayerPos.x, targetPlayerPos.y, defaultPlayerPos.z), .35f);
    }

    [ContextMenu("Show Menu")]
    public void ShowPlayerMenu()
    {
        playerDeck.transform.DOMove(new Vector3(defaultPlayerPos.x, defaultPlayerPos.y, defaultPlayerPos.z), .35f);
    }

    public void HideEnemyMenu()
    {
        enemyDeck.transform.DOMove(new Vector3(defaultEnemyPos.x, targetEnemyPos.y, defaultEnemyPos.z), .35f);
    }

    public void ShowEnemyMenu()
    {
        enemyDeck.transform.DOMove(new Vector3(defaultEnemyPos.x, defaultEnemyPos.y, defaultEnemyPos.z), .35f);
    }
}
