using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UM_SceneLink : MonoBehaviour
{

    [SerializeField] private string m_SceneName  = null;
    //[SerializeField] private Object m_Scene = null;


    public string SceneName
    {
        get { return m_SceneName; }
    }
}
