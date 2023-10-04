using FightingScene.UnitSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class Buff
    {
        private Action myAction;
        private bool isFirstRound = true;
        private int leftTurn;
        protected UnitMono target;
        protected BuffSO buffSO;

        public Buff(BuffSO _buffSO)
        {
            this.buffSO = _buffSO;
            leftTurn = buffSO.existTurn;
        }
        public enum ApplyTime
        {
            TurnStart,
            TurnEnd,
            wholeTurnStart,
        }

        public enum Type
        {
            EveryRound,
            OneTime
        }

        public void AddBuff(UnitMono _target)
        {
            target = _target;

            switch (buffSO.applyTime)
            {
                case ApplyTime.TurnStart:
                    if (_target.gameObject.name == "Player")
                    {
                        FightingManager.Instance.OnPlayerRoundStartAction += BuffApply;
                        myAction = FightingManager.Instance.OnPlayerRoundStartAction;
                    }
                    else
                    {
                        FightingManager.Instance.OnEnemyRoundStartAction += BuffApply;
                        myAction = FightingManager.Instance.OnEnemyRoundStartAction;
                    }
                    break;
                case ApplyTime.TurnEnd:
                    if (_target.gameObject.name == "Player")
                    {
                        FightingManager.Instance.OnPlayerRoundEndAction += BuffApply;
                        myAction = FightingManager.Instance.OnPlayerRoundEndAction;
                    }
                    else
                    {
                        FightingManager.Instance.OnEnemyRoundStartAction += BuffApply;
                        myAction = FightingManager.Instance.OnEnemyRoundStartAction;
                    }
                    break;
                case ApplyTime.wholeTurnStart:
                    FightingManager.Instance.OnWholeRoundStartAction += BuffApply;
                    myAction = FightingManager.Instance.OnWholeRoundStartAction;
                    break;
                default:
                    break;
            }
        }
        protected void BuffApply()
        {
            leftTurn--;
            if (leftTurn == -1)
            {
                BuffDisable(target);
                
            }
            if (leftTurn < 0)
            {
                return;
            }
            if (buffSO.type == Type.OneTime)
            {
                if (isFirstRound)
                {
                    BuffEffect(target);
                    isFirstRound = false;
                }
            }
            else
            {
                BuffEffect(target);
            }
            Debug.Log($"Buff{buffSO.name}生效,剩余{leftTurn}回合");
        }

        protected virtual void BuffEffect(UnitMono _target)
        {

        }

        protected virtual void BuffDisable(UnitMono _target)
        {
            myAction -= BuffApply;
            Debug.Log($"Buff{buffSO.name}失效");

        }
    }
}