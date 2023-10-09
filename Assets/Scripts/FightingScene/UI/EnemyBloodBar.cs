using EcustGamejam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBloodBar : MonoBehaviour
{
    public Image enemyBloodBar;

    // Update is called once per frame
    void Update()
    {
        enemyBloodBar.fillAmount = (float)FightingManager.Instance.enemy.CurrentHp / FightingManager.Instance.enemy.maxHp;
    }
}
