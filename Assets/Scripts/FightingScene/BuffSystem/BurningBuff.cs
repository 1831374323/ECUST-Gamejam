using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FightingScene.UnitSystem;

namespace EcustGamejam
{

    public class BurningBuff : Buff
    {
        private BurningBuffSO burningBuffSO;
        public BurningBuff(BuffSO _buffSO) : base(_buffSO)
        {
            burningBuffSO = (BurningBuffSO)_buffSO;
        }

        protected override void BuffDisable(UnitMono _target)
        {
            base.BuffDisable(base.target);

        }

        protected override void BuffEffect(UnitMono _target)
        {
            base.BuffEffect(base.target);
            Debug.Log(burningBuffSO.probability[level] + "%¸ÅÂÊ½øÐÐ×ÆÉÕ");

            if (Random.Range(0, 100) < burningBuffSO.probability[base.level])
            {

                FightingManager.Instance.DoDamage(burningBuffSO.burningValue, base.target);
            }
        }


    }
}
