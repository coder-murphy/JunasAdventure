using Assets.FDGameSDK.Components;
using Assets.FDGameSDK.GameObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField]
    GameObject closeBtn;

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

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Items = new List<FDItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
