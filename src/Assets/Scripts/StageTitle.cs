using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTitle : MonoBehaviour
{
    /// <summary>
    /// 标题
    /// </summary>
    public GameObject Title;
    // Start is called before the first frame update
    void Start()
    {
        ShowTitle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowTitle()
    {
        var img = Title.GetComponent<Image>();
        img.color = new Color(1f, 1f, 1f, 0f);
        Title.SetActive(true);
        var seq = DOTween.Sequence();
        seq.Append(img.DOColor(new Color(1f, 1f, 1f, 1f), 1.5f))
            .Append(img.DOColor(new Color(1f, 1f, 1f, 1f), 1.5f))
            .AppendCallback(() => {
                TitleShowCompleted?.Invoke();
            });
    }

    /// <summary>
    /// 当关卡标题展示结束时
    /// </summary>
    public event StageTitleEventHandler TitleShowCompleted;
}

public delegate void StageTitleEventHandler();
