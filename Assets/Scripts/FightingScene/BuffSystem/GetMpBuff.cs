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
            //_target.cureMp -= changeValue;
            changeValue = 0;
        }

        protected override void BuffEffect(UnitMono _target)
        {
            base.BuffEffect(_target);
            //_target.cureMp += getMpBuffSO.extraMpCure;
            _target.SetMp(getMpBuffSO.extraMpCure);
            Debug.Log(target.gameObject.name+"更改回蓝量为"+ _target.cureMp);
            changeValue = getMpBuffSO.extraMpCure;


        }
    }
}