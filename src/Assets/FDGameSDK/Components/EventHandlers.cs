using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FDGameSDK.Components
{
    /// <summary>
    /// 事件
    /// </summary>
    public class FDEventArgs : EventArgs
    {
        /// <summary>
        /// 事件携带对象
        /// </summary>
        public object Item { get; set; }
    }

    /// <summary>
    /// 事件委托
    /// </summary>
    public delegate void FDEventHandler();

    /// <summary>
    /// 带参事件委托
    /// </summary>
    public delegate void FDParamEventHandler(FDEventArgs args);

}
