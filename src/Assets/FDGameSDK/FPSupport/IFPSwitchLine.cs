using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FDGameSDK.FPSupport
{
    /// <summary>
    /// switch行必备参数
    /// </summary>
    public interface IFPSwitchLine<T>
    {
        /// <summary>
        /// 源数据
        /// </summary>
        T Src { get; set; }

        /// <summary>
        /// 判断表达式
        /// </summary>
        Func<T, bool> Expression { get; set; }

        /// <summary>
        /// 如果满足条件执行动作
        /// </summary>
        Action<T> MyAction { get; set; }
    }
}
