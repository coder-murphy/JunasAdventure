using Assets.FDGameSDK.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FDObjectBase : MonoBehaviour, IFDObjectBase
{
    private string _Uid = null;
    /// <summary>
    /// 唯一标识
    /// </summary>
    public string Uid { 
        get {
            if (_Uid == null)
                _Uid = Guid.NewGuid().ToString();
            return _Uid;
        }
        set => _Uid = value;
    }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }
    public string Desc { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
