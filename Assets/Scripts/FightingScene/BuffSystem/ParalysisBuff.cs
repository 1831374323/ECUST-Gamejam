using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class ParalysisBuff : Buff
    {
        private ParalysisBuffSO paralysisBuffSO;
        private int speedChangeValue=0;
        public ParalysisBuff(BuffSO _buffSO) : base(_buffSO)
        {
            paralysisBuffSO = (ParalysisBuffSO)_buffSO;
        }

        protected override void BuffDisable(UnitMono _target)
        {
            base.BuffDisable(_target);
            _target.speed += speedChangeValue;
            speedChangeValue = 0;
        }

        protected override void BuffEffect(UnitMono _target)
        {
            base.BuffEffect(_target);
            Debug.Log(paralysisBuffSO.probability[base.level] + "%¸ÅÂÊ´¥·¢Âé±Ô");

            if (Random.Range(0, 100) < paralysisBuffSO.probability[base.level])
            {
                speedChangeValue = _target.speed;
                _target.speed = 0;
            }

        }


    }
}