using Assets.FDGameSDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.FDGameSDK
{
    public static class Extensions
    {
        /// <summary>
        /// 对集合元素进行遍历操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tSource"></param>
        /// <param name="doAction"></param>
        public static void ForAll<T>(this IEnumerable<T> tSource, Action<T> doAction)
        {
            foreach (var i in tSource)
            {
                doAction(i);
            }
        }
    }
}
