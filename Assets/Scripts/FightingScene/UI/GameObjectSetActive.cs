using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSetActive : MonoBehaviour
{
    public GameObject obj;
    public void Close()
    {
        obj.SetActive(false);
    }

    public void Show()
    {
        obj.SetActive(true);
    }
}
