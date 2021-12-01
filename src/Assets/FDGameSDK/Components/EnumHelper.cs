using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FDGameSDK.Components
{
    /// <summary>
    /// 枚举助手
    /// </summary>
    public class EnumHelper<TEnum> where TEnum : Enum
    {
        /// <summary>
        /// 新建一个枚举助手
        /// </summary>
        public EnumHelper()
        {
            innerEnumType = typeof(TEnum);
            innerEnumNames = new ReadOnlyCollection<string>(Enum.GetNames(innerEnumType).ToList());
            var vals = new List<object>();
            var arr = Enum.GetValues(innerEnumType);
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                vals.Add(arr.GetValue(i));
            }
            innerEnumValues = new ReadOnlyCollection<object>(vals);
        }

        /// <summary>
        /// 获取所有枚举成员
        /// </summary>
        /// <returns></returns>
        public string[] GetNames() => innerEnumNames.ToArray();

        /// <summary>
        /// 获取所有枚举值
        /// </summary>
        /// <returns></returns>
        public object[] GetValues() => innerEnumValues.ToArray();

        /// <summary>
        /// 将枚举成员和值转化为字典
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            for (int i = 0; i < innerEnumNames.Count; i++)
            {
                dict.Add(innerEnumNames[i], innerEnumValues[i]);
            }
            return dict;
        }

        /// <summary>
        /// 将对象转化为指定的枚举
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public TEnum Parse(object input)
        {
            if (input == null)
                return default(TEnum);
            return (TEnum)Enum.Parse(innerEnumType, input.ToString());
        }

        /// <summary>
        /// 根据字符串名称获取枚举
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TEnum Parse(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return default(TEnum);
            return (TEnum)Enum.Parse(innerEnumType, name);
        }

        /// <summary>
        /// 是否存在枚举成员
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsMamber(string name) => innerEnumNames.Contains(name);
        /// <summary>
        /// 获取指定枚举成员名的索引
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int FindIndex(string name) => innerEnumNames.IndexOf(name);

        /// <summary>
        /// 获取枚举成员数量
        /// </summary>
        public int MemberCount => innerEnumValues.Count;

        /// <summary>
        /// 获取该枚举类型的名字
        /// </summary>
        public string Name => innerEnumType.Name;

        /// <summary>
        /// 枚举完整名字
        /// </summary>
        public string FullName => innerEnumType.FullName;

        #region private members
        private Type innerEnumType = null;
        private ReadOnlyCollection<string> innerEnumNames = null;
        private ReadOnlyCollection<object> innerEnumValues = null;
        #endregion
    }
}
