using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class Enemy0 : EnemyBase
    {
        protected override void SkillSection()
        {
            switch (coinResult)
            {
                case 0:
                case 1:
                case 2:
                    StartCoroutine(DoSkill(myData.skillRecycle[0]));
                    break;
                case 3:
                case 4:
                    StartCoroutine(DoSkill(myData.skillRecycle[1]));
                    break;
                case 5:
                case 6:
                    StartCoroutine(DoSkill(myData.skillRecycle[2]));
                    break;
                default:
                    break;
            }


        }
    }
}