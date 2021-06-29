using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lv3森林场景脚本
/// </summary>
public class ForestStageLv3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EntryBattleArea ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 进入战斗场景
    /// </summary>
    private void EntryBattleArea()
    {
        ShowAreaTitle();
    }

    private void ShowAreaTitle()
    {
        
    }

    private void Init()
    {
        MonsterSet();
    }

    /// <summary>
    /// 怪物设置
    /// </summary>
    private void MonsterSet()
    {
        Debug.Log("怪物放置完毕");
    }
}

public delegate void CustomEventHandler();