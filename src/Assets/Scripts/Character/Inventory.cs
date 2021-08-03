using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
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
        Items = new List<FDItem>();
        //Items.Repeat
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
