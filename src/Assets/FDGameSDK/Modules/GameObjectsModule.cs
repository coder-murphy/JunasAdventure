using Assets.FDGameSDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.FDGameSDK
{
    /// <summary>
    /// 游戏对象支持
    /// </summary>
    public class GameObjectsSupports
    {
        /// <summary>
        /// 初始化一个指定大小的物品List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static List<T> RepeatItems<T>(uint count, T defaultValue)
            where T : MonoBehaviour, IFDItem, new()
        {
            var temp = new List<T>();
            for (int i = 0; i < count; i++)
            {
                var item = new T
                {
                    Id = defaultValue.Id,
                    enabled = defaultValue.enabled
                };
                temp.Add(item);
            }
            return temp;
        }

        /// <summary>
        /// 初始化一个指定大小的unity对象List
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<T> Repeat<T>(T value,uint count)
            where T : UnityEngine.Object
        {
            var temp = new List<T>();
            for (int i = 0; i < count; i++)
            {
                temp.Add(UnityEngine.Object.Instantiate(value));
            }
            return temp;
        }
    }
}
