using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingScene.UnitSystem;
using UnityEngine.UI;
using System;

namespace EcustGamejam
{
    public class EnemyBase : UnitMono
    {
        public EnemySO myData;
        private int currentSkillIndex = 0;
        protected int coinResult = 0;


        protected virtual void Awake()
        {
            myData = GameManager.Instance.enemySO;
            FightingManager.Instance.OnEnemyRoundStartAction += EnemyRoundStart;
            maxHp = myData.maxHp;
            currentHp = maxHp;
            speed = myData.speed;
            shield = myData.shield;

            increaseValue = 1;
            decreaseValue = 1;
            shieldIncreaseValue = 1;

            gameObject.GetComponent<Image>().sprite = myData.image;

        }

        public void EnemyRoundStart()
        {

            StartCoroutine(EnemyRound());

        }

        IEnumerator EnemyRound()
        {
            Debug.Log("Enemy Base�����˻غϿ�ʼ");
            CoinSection();
            yield return new WaitForSeconds(3);
            SkillSection();
            yield return new WaitForSeconds(3);
            FightingManager.Instance.OnEnemyRoundEnd();
        }

        protected virtual void CoinSection()
        {
            coinResult = UnityEngine.Random.Range(0, 7);
            currentPosition = (currentPosition + coinResult) % 8;
            FightingUIManager.Instance.UpdateEnemyPosition();
            FightingUIManager.Instance.UpDateBehaviourText($"����������{coinResult}��");
        }
        protected virtual void SkillSection()
        {
            if (currentSkillIndex >= myData.skillRecycle.Count)
            {
                currentSkillIndex = 0;
            }

            if (currentPosition == myData.buffPosition.id)
            {
                //��������Ч��
            }
            else
            {

                myData.skillRecycle[currentSkillIndex].SkillApply(this, FightingManager.Instance.player);
            }

            currentSkillIndex++;
        }

    }
}