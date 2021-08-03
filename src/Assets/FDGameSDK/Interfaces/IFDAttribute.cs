using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FDGameSDK.Interfaces
{
    /// <summary>
    /// 属性接口
    /// </summary>
    public interface IFDAttribute : IFDUtil
    {
        object Value { get; set; }
    }
}
