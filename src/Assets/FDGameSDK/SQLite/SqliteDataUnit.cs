using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.FDGameSDK.SQLite
{
    /// <summary>
    /// 单个sqlie数据
    /// </summary>
    public class SqliteDataUnit
    {
        /// <summary>
        /// 新建一个sqlite数据
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        public SqliteDataUnit(string columnName,string value)
        {
            ColumnName = columnName;
            Value = value;
        }

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
