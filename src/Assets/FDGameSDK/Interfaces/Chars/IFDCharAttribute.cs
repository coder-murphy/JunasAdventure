using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FDGameSDK.Interfaces.Chars
{
    /// <summary>
    /// 角色属性接口
    /// </summary>
    public interface IFDCharAttribute : IFDAttribute
    {
        /// <summary>
        /// 角色属性类型id
        /// </summary>
        uint CharAttId { get; set; }
    }
}
