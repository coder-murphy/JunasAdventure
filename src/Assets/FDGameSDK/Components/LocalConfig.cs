using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Assets.FDGameSDK.Components
{
    /// <summary>
    /// 本地配置
    /// </summary>
    public class LocalConfig
    {
        /// <summary>
        /// 读取ini配置文件
        /// </summary>
        /// <param name="sectionName">要读取的section名,如果传入null获取ini文件所有的section名</param>
        /// <param name="key">要读取的key,如果传入null获取此section名下的所有key</param>
        /// <param name="defaultValue">读取异常的情况下的缺省值</param>
        /// <param name="returnBuffer">key所对应的值，如果该key不存在则返回defaultValue</param>
        /// <param name="size">值允许的大小</param>
        /// <param name="filePath">ini文件的完整路径和文件名</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string sectionName, string key, string defaultValue, StringBuilder returnBuffer, int size, string filePath);

        /// <summary>
        /// 写入ini配置文件
        /// </summary>
        /// <param name="sectionName">要写入的section名</param>
        /// <param name="key">要写入的key，如果传入为null，整个sectionName被清除</param>
        /// <param name="value">key所对应的值，如果传入为null，此key将被清除</param>
        /// <param name="filePath">ini文件的完整路径和文件名</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string sectionName, string key, string value, string filePath);

        /// <summary>
        /// 读取ini配置(非绝对路径也可以)
        /// </summary>
        public static void GetSettingValue(string sectionName, string key, string filePath, out string value)
        {
            StringBuilder returnBuffer = new StringBuilder(MaxIniBufferSize);
            string fullName = new FileInfo(filePath).FullName;
            int size = GetPrivateProfileString(sectionName, key, "NULL", returnBuffer, MaxIniBufferSize, fullName);
            // 掐掉终止符
            value = returnBuffer.ToString();
        }

        /// <summary>
        /// 向ini中放置配置(非绝对路径也可以)
        /// </summary>
        public static void PutSetting(string sectionName, string key, string value, string filePath)
        {
            string fullName = new FileInfo(filePath).FullName;
            WritePrivateProfileString(sectionName, key, value, fullName);
        }

        /// <summary>
        /// 允许最大读取配置设置的buffer长度
        /// </summary>
        public const int MaxIniBufferSize = 512;
    }
}
