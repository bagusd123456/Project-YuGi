using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

namespace SilentHysteria
{
    public class BattleSystem : MonoBehaviour
    {
        private static BattleSystem instance;

        public static BattleSystem Instance
        {
            get { return instance; }
        }

        void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }

        [SerializeField]
        public Card playerCard;
        public Card targetCard;
        [Space]
        [Range(0, 10)]
        public float speed = 1;
        public Color startColor;
        public Color endColor = Color.black;

        public bool canAttack = true;
        [Header("Turn Parameter")]
        public attackState _attackState = attackState.IDLE;
        [SerializeField] public enum attackState { IDLE, CHOOSECARD, CHOOSETARGET, BUSY };

        // Start is called before the first frame update
        void Start()
        {
            //canAttack = true;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            if(playerCard != null)
            {
                playerCard.GetComponent<Image>().color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
            }

            if(targetCard != null)
            {
                targetCard.GetComponent<Image>().color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
            }
                
        }

        public void Attack()
        {
            if (targetCard != null)
            {
                if (playerCard.cardDataSO.attackValue > targetCard.cardDataSO.attackValue)
                    Destroy(targetCard.gameObject);
                else if(playerCard.cardDataSO.attackValue < targetCard.cardDataSO.attackValue)
                    Destroy(playerCard.gameObject);
                else if (playerCard.cardDataSO.attackValue == targetCard.cardDataSO.attackValue)
                {
                    Destroy(playerCard.gameObject);
                    Destroy(targetCard.gameObject);
                }
                    
            }
            else
                Debug.Log("Target is Null");

            _attackState = attackState.IDLE;
        }

        public void SetupAttack()
        {
            canAttack = true;
            StartCoroutine(ChooseTarget());
        }

        public IEnumerator ChooseTarget()
        {
            Debug.Log("Attack Sequence");

            yield return new WaitForSeconds(1f);
            Debug.Log("Choose Target");
            _attackState = attackState.CHOOSECARD;

        }

        private void OnDrawGizmos()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * 10);
        }
    }

}
