using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

namespace Assets.FDGameSDK.SQLite
{
    /// <summary>
    /// 基于SQLite的数据提供者
    /// </summary>
    public class DataProvider
    {
        private SqliteConnection sqliteConnection = null;
        private SqliteCommand sqliteCommand = null;
        private SqliteDataReader dataReader = null;

        private bool _IsDataProviderInit = false;
        /// <summary>
        /// 数据提供者是否初始化
        /// </summary>
        public bool IsDataProviderInit => _IsDataProviderInit;

        /// <summary>
        /// 初始化sqlite
        /// </summary>
        /// <param name="dbAddress"></param>
        public void Init(string dbAddress)
        {
            InitDB($"Data Source={dbAddress}");
            Debug.Log($"Data Source={dbAddress}");
        }


        private void InitDB(string dbAddressCommand)
        {
            try
            {
                sqliteConnection = new SqliteConnection(dbAddressCommand);
                sqliteConnection.Open();
                _IsDataProviderInit = true;
                Debug.Log($"SQLite 服务开启");
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void CloseConnection()
        {
            if (IsDataProviderInit == false) return;
            sqliteCommand = null;
            dataReader = null;
            if (sqliteConnection != null)
                sqliteConnection.Clone();
            sqliteConnection = null;
            Debug.Log($"SQLite 服务关闭");
        }

        /// <summary>
        /// 运行指令
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public SqliteDataReader ExecuteQuery(string queryString)
        {
            if (IsDataProviderInit == false) return null;
            Debug.Log($"Run Query:{queryString}");
            sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = queryString;
            dataReader = sqliteCommand.ExecuteReader();
            return dataReader;
        }

        /// <summary>
        /// 获取插入数据的命令串
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public string GetInsertDataQuery(string tableName, params object[] values)
        {
            string query = $"INSERT INTO {tableName} VALUES(";
            int count = 0;
            int len = values.Length;
            foreach(var i in values.Select(x => x.ToString()))
            {
                count++;
                if(count == len)
                {
                    query += $"\"{i}\"";
                }
                else
                {
                    query += $"\"{i}\",";
                }
            }
            if(query.Last() == ',')
                query.Remove(query.Length - 1, 1);
            query += ")";
            return query;
        }

        /// <summary>
        /// 获取插入数据的命令串
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public string GetInsertDataQuery(string tableName, params SqliteDataUnit[] values)
        {
            string query = $"INSERT INTO {tableName} ";
            string columns = "(";
            string valueStrings = "VALUES (";
            int count = 0;
            int len = values.Length;
            foreach (var i in values.Select(x => x))
            {
                count++;
                if (count == len)
                {
                    columns += $"\"{i.ColumnName}\") ";
                    valueStrings += $"\"{i.Value}\")";
                }
                else
                {
                    columns += $"\"{i.ColumnName}\",";
                    valueStrings += $"\"{i.Value}\",";
                }
            }
            query += columns;
            query += valueStrings;
            return query;
        }

        /// <summary>
        /// 获取所有数据的sql串
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetAllDataQuery(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return query;
        }

        /// <summary>
        /// 获取表中所有索引的查询串
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="indexKeyName"></param>
        /// <returns></returns>
        public string GetAllIndexQuery(string tableName,string indexKeyName)
        {
            string query = $"SELECT {indexKeyName} FROM {tableName}";
            return query;
        }
    }
}
