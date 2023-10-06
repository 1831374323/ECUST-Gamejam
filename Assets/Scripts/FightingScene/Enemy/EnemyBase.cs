using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingScene.UnitSystem;

namespace EcustGamejam
{
    public class EnemyBase : UnitMono
    {
        public EnemySO myData;
        private int currentSkillIndex = 0;
        protected int coinResult = 0;

        protected virtual void Awake()
        {
            FightingManager.Instance.OnEnemyRoundStartAction += EnemyRoundStart;
            maxHp = myData.maxHp;
            //CurrentHp = maxHp;

        }

        public void EnemyRoundStart()
        {
            CoinSection();
            SkillSection();
            FightingManager.Instance.OnEnemyRoundEnd();
        }

        protected virtual void CoinSection()
        {
            coinResult = Random.Range(0, 7);
            currentPosition = (currentPosition + coinResult) % 8;

            StartCoroutine(Delay());
        }
        protected virtual void SkillSection()
        {
            if (currentSkillIndex >= myData.skillRecycle.Count)
            {
                currentSkillIndex = 0;
            }

            StartCoroutine(DoSkill(myData.skillRecycle[currentSkillIndex]));

            currentSkillIndex++;
        }

        protected IEnumerator DoSkill(SkillBase skill)
        {

            skill.SkillApply(this, FightingManager.Instance.player);

            Debug.Log($"µ–»À Õ∑≈¡À{skill.m_name}");
            yield return new WaitForSeconds(3);

        }

        protected IEnumerator Delay()
        {
            yield return new WaitForSeconds(3);
        }
    }
}