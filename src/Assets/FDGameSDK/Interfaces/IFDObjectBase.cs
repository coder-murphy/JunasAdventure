﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FDGameSDK.Interfaces
{
    /// <summary>
    /// 提供游戏对象的基接口
    /// </summary>
    public interface IFDObjectBase
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        string Uid { get; set; }
    }
}
