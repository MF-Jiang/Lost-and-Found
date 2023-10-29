using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenuController : MonoBehaviour
{
    /// <summary>
    /// 一个简单的控制器，用于在UI面板之间切换。
    /// </summary>
    public GameObject[] panels;

    public void SetActivePanel(int index)
    {
        for (var i = 0; i < panels.Length; i++)
        {
            var active = i == index;
            var g = panels[i];
            if (g.activeSelf != active) g.SetActive(active);
        }
    }

    void OnEnable()
    {
        SetActivePanel(0);
    }
}

