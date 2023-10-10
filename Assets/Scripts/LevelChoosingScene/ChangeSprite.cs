using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public Image image;
    public Sprite normal;
    public Sprite chosen;

    public void PointEnter()
    {
        image.sprite = chosen;
    }

    public void PointExit()
    {
        image.sprite = normal;
    }
}
