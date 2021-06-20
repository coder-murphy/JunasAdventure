using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
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
        _RootCanvas = GameObject.Find("Canvas");
        EntryBattleArea ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject _AreaTitle = null;
    private GameObject _RootCanvas = null;

    /// <summary>
    /// 进入战斗场景
    /// </summary>
    private void EntryBattleArea()
    {
        ShowAreaTitle();
    }

    private void ShowAreaTitle()
    {
        _AreaTitle = Instantiate(Resources.Load("Prefabs/StageTitle")) as GameObject;
        _AreaTitle.SetActive(true);
        RectTransform tran = _AreaTitle.GetComponent<RectTransform>();
        _AreaTitle.GetComponent<StageTitle>().TitleShowCompleted += () => Init();
        tran.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, _RootCanvas.GetComponent<RectTransform>().rect.height);
        tran.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, _RootCanvas.GetComponent<RectTransform>().rect.width);
        _AreaTitle.transform.SetParent(_RootCanvas.transform);
    }

    private void Init()
    {
        Debug.Log("展示完毕");
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
