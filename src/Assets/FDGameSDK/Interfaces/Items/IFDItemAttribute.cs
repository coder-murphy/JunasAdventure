using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FDGameSDK.Interfaces.Items
{
    /// <summary>
    /// 物品属性
    /// </summary>
    public interface IFDItemAttribute : IFDAttribute
    {
        /// <summary>
        /// 属性ID
        /// </summary>
        uint ItemAttId { get; set; }

        /// <summary>
        /// 属性最大值
        /// </summary>
        object MaxValue { get; set; }

        /// <summary>
        /// 属性最小值
        /// </summary>
        object MinValue { get; set; }
    }
}
