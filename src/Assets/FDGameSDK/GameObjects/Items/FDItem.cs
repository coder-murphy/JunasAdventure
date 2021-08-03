using Assets.FDGameSDK.Interfaces;
using Assets.FDGameSDK.Interfaces.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 物品
/// </summary>
public class FDItem : MonoBehaviour, IFDItem
{
    public string Uid { get; set; }
    public string Name { get; set; }
    public int Id { get; set; }
    public short UseTimes { get; set; }
    public uint Cost { get; set; }
    public string Desc { get; set; }

    private List<IFDItemAttribute> _Attributes = null;
    public List<IFDItemAttribute> Attributes { 
        get
        {
            if (_Attributes == null)
                _Attributes = new List<IFDItemAttribute>();
            return _Attributes;
        }
        set => _Attributes = value; }

    public Image BackImage;
    public Image FrameImage;
    public Image ItemImage;
    public GameObject BackGround;
    public GameObject Frame;
    public GameObject Item;
    private RectTransform rect;

    public static FDItem Empty => new FDItem
    {
        enabled = false,
        Id = -1,
    };

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        BackImage = BackGround.GetComponent<Image>();
        FrameImage = Frame.GetComponent<Image>();
        ItemImage = Item.GetComponent<Image>();
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
