using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class GetMpBuff : Buff
    {
        private GetMpBuffSO getMpBuffSO;
        private int changeValue = 0;

        public GetMpBuff(BuffSO _buffSO) : base(_buffSO)
        {
            getMpBuffSO = (GetMpBuffSO)_buffSO;
        }

        protected override void BuffDisable(UnitMono _target)
        {
            base.BuffDisable(_target);
            _target.cureMp -= changeValue;
            changeValue = 0;
        }

        protected override void BuffEffect(UnitMono _target)
        {
            base.BuffEffect(_target);
            Debug.Log(getMpBuffSO.probability[base.level] + "%概率触发额外回蓝");

            if (Random.Range(0, 100) < getMpBuffSO.probability[base.level])
            {
                _target.cureMp += getMpBuffSO.extraMpCure;
                changeValue = getMpBuffSO.extraMpCure;
            }

        }
    }
}