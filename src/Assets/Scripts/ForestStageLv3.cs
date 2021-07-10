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
    GameManager _GameManager => GameObject.Find("GameManager").GetComponent<GameManager>();

    private void Awake()
    {
        EntryBattleArea();
    }

    void Start()
    {
        Debug.Log("加载ui完毕");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject _RootCanvas = null;

    private GameObject _CharProfile = null;
    /// <summary>
    /// 读取界面
    /// </summary>
    private void LoadUI()
    {
        _RootCanvas = GameObject.Find("Canvas");
        _CharProfile = Instantiate(Resources.Load("Prefabs/UI/CharProfile")) as GameObject;
        _CharProfile.transform.SetParent(_RootCanvas.transform);
        _CharProfile.SetActive(true);
    }


    /// <summary>
    /// 进入战斗场景
    /// </summary>
    private void EntryBattleArea()
    {
        Init();
    }



    private void Init()
    {
        LoadUI();
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