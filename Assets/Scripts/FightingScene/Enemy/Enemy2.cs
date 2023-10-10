using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{

    public class Enemy2 : EnemyBase
    {
        protected override void SkillSection()
        {
            if (currentPosition == myData.buffPosition.id)
            {
                switch (coinResult)
                {
                    case 0:
                    case 1:
                    case 2:
                        myData.skillRecycle[0].SkillBuffedApply(this, FightingManager.Instance.player);
                        break;
                    case 3:
                    case 4:
                        myData.skillRecycle[1].SkillBuffedApply(this, FightingManager.Instance.player);
                        break;
                    case 5:
                    case 6:
                        myData.skillRecycle[2].SkillBuffedApply(this, FightingManager.Instance.player);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (coinResult)
                {
                    case 0:
                    case 1:
                    case 2:
                        myData.skillRecycle[0].SkillApply(this, FightingManager.Instance.player);
                        break;
                    case 3:
                    case 4:
                        myData.skillRecycle[1].SkillApply(this, FightingManager.Instance.player);
                        break;
                    case 5:
                    case 6:
                        myData.skillRecycle[2].SkillApply(this, FightingManager.Instance.player);
                        break;
                    default:
                        break;
                }
            }


        }

    }
}