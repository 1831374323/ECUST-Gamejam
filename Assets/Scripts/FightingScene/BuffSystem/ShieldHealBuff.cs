using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingScene.UnitSystem;

namespace EcustGamejam
{    
    public class ShieldHealBuff : Buff
    {
        private ShieldHealBuffSO shieldHealBuffSO;
        private float changeValue = 0;
        public ShieldHealBuff(BuffSO _buffSO) : base(_buffSO)
        {
            shieldHealBuffSO = (ShieldHealBuffSO)_buffSO;
        }
        protected override void BuffDisable(UnitMono _target)
        {
            base.BuffDisable(_target);
            changeValue = 0;
        }
        protected override void BuffEffect(UnitMono _target)
        {
            base.BuffEffect(_target);
            Debug.Log("%获得"+shieldHealBuffSO.rate[base.level] + "%你当前护盾的生命值");          
            changeValue = shieldHealBuffSO.rate[base.level] * _target.shield;
            _target.SetHp((int)changeValue);
        }
    }
}
