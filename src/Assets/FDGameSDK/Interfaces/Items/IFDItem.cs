using Assets.FDGameSDK.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.FDGameSDK.Interfaces
{
    /// <summary>
    /// 物品接口
    /// </summary>
    public interface IFDItem : IFDObjectBase
    {
        int Id { get; set; }

        uint Cost { get; set; }

        /// <summary>
        /// 使用次数（如果为-1则不是消耗品）
        /// </summary>
        short UseTimes { get; set; }

        /// <summary>
        /// 属性列表
        /// </summary>
        List<IFDItemAttribute> Attributes { get; set; }
    }
}
