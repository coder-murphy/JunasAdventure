using Assets.FDGameSDK.Components;
using Assets.FDGameSDK.GameObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : Singleton<Inventory>, IDragHandler, IBeginDragHandler
{
    [SerializeField]
    GameObject closeBtn;

    [SerializeField]
    private RectTransform rectTransform;

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        double canDragGap = rectTransform.position.y - eventData.position.y;
        //Debug.Log(eventData.position);
        Debug.Log(canDragGap);
        if (canDragGap <= 75)
            rectTransform.anchoredPosition += eventData.delta;
    }

    /// <summary>
    /// 物品栏中的物品
    /// </summary>
    public FDItem this[int row, int column]
    {
        get
        {
            int r = (row - 1) * RowMax;
            int c = (column - 1) * ColumnMax;
            return Items[r + c];
        }
        set
        {
            int r = (row - 1) * RowMax;
            int c = (column - 1) * ColumnMax;
            Items[r + c] = value;
        }
    }

    /// <summary>
    /// 窗口关闭
    /// </summary>
    public event FDEventHandler Closed = null;

    /// <summary>
    /// 最大行数
    /// </summary>
    public const int RowMax = 8;

    /// <summary>
    /// 最大列数
    /// </summary>
    public const int ColumnMax = 6;

    private List<FDItem> Items = null;

    // Start is called before the first frame update
    void Start()
    {
        Items = new List<FDItem>();
        closeBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// 设置仓库可见性
    /// </summary>
    /// <param name="flag"></param>
    public void SetVisible(bool flag)
    {
        gameObject.SetActive(flag);
    }
}
