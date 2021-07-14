using Assets.FDGameSDK.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DataManager
{
    /// <summary>
    /// 数据管理者
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// 数据提供者
        /// </summary>
        private DataProvider _DataProvider;

        /// <summary>
        /// 数据库路径
        /// </summary>
        public static string DataBasePath => $"{Directory.GetCurrentDirectory()}\\Data\\JunaAdvDataBase.db";

        /// <summary>
        /// 初始化数据管理者
        /// </summary>
        public void Init()
        {
            _DataProvider = new DataProvider();
            _DataProvider.Init(DataBasePath);
        }

        /// <summary>
        /// 关闭数据服务
        /// </summary>
        public void CloseService()
        {
            _DataProvider.CloseConnection();
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddCharInfo(string name)
        {
            var query = _DataProvider.GetInsertDataQuery("CharData",
                new SqliteDataUnit("name", name),
                new SqliteDataUnit("hp", "50"),
                new SqliteDataUnit("mp", "40"));
            var reader = _DataProvider.ExecuteQuery(query);
            return true;
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool GetAllInfos(string tableName)
        {
            var query = _DataProvider.GetAllDataQuery(tableName);
            var reader = _DataProvider.ExecuteQuery(query);
            while(reader.Read())
            {
                Debug.Log($"id:{reader.GetInt32(0)},name:{reader.GetString(1)}");
            }
            return true;
        }
    }
}
