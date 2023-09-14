using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;
    private static object m_instanceLock = new object();

    public static T Instance
    {
        get
        {
            lock (m_instanceLock)
            {

                if (m_instance == null)
                {
                    //�����Ƿ��Ѿ������ڳ���
                    m_instance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        return m_instance;
                    }

                    //�������򴴽�һ��
                    if (m_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        m_instance = singleton.AddComponent<T>();
                        singleton.name = "singleton " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);
                    }
                }

                return m_instance;
            }

        }
    }

    protected virtual void OnDestroy()
    {
        m_instance = null;
    }
}
