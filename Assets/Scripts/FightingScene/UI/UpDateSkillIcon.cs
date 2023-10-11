using EcustGamejam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDateSkillIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = PositionManager.Instance.positions[FightingManager.Instance.player.currentPosition].attackskill.icon;
    }
}
