using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class DamageReduceBuff : Buff
    {
        private DamageReduceBuffSO damageRecudeBuffSO;
        private int decreaseValue;
        public DamageReduceBuff(BuffSO _buffSO) : base(_buffSO)
        {
            damageRecudeBuffSO = (DamageReduceBuffSO)_buffSO;
        }

        protected override void BuffDisable(UnitMono _target)
        {
            base.BuffDisable(base.target);
            _target.decreaseValue += damageRecudeBuffSO.decreaseValue[level];
        }

        protected override void BuffEffect(UnitMono _target)
        {
            base.BuffEffect(base.target);
            Debug.Log("π÷ŒÔ…À∫¶ºı…Ÿ"+ damageRecudeBuffSO.decreaseValue[level]*100+"%");

            _target.decreaseValue -= damageRecudeBuffSO.decreaseValue[level];

        }
    }
}