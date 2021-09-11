using Assets.FDGameSDK.Components;
using Assets.FDGameSDK.FPSupport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.FDGameSDK.Modules
{
    /// <summary>
    /// 键盘事件模块
    /// </summary>
    public class InputModule : MonoBehaviour
    {
        /// <summary>
        /// 键盘模块唯一实例
        /// </summary>
        public static InputModule Instance = null;

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public const string ConfigFilePath = "gameconfig.ini";

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
            {
                Instance = this;
                Init();
            }
            if (File.Exists(ConfigFilePath) == false)
            {
                File.Create(ConfigFilePath);
                LocalConfig.PutSetting("KeyBoard", "KeyDown", "", ConfigFilePath);
            }
        }

        private IEnumerable<IFPSwitchLine<KeyTypes>> keyTypeSwitchs = null;
        private void Init()
        {
            var vals = Enum.GetValues(typeof(KeyTypes));
        }

        /// <summary>
        /// 注册键位
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyCode"></param>
        public void RegisterKey(KeyTypes keyTypes, KeyCode keyCode)
        {

        }

        /// <summary>
        /// 获取键位名称
        /// </summary>
        /// <param name="keyTypes"></param>
        /// <returns></returns>
        public string GetKeyTypesString(KeyTypes keyTypes)
        {
            return "UnKnown";
        }

        /// <summary>
        /// 放置键位事件
        /// </summary>
        /// <param name="keyCode"></param>
        public void PushKeyEvent(KeyCode keyCode)
        {
            //EnumHelper<KeyTypes> enumHelper = new EnumHelper<KeyTypes>();

        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<KeyTypes> CustomKeyDownEvent = null; 
    }

    /// <summary>
    /// 键位类型
    /// </summary>
    public enum KeyTypes
    {
        Attack,
        Up,
        Right,
        Down,
        Left,
        Jump,
        PickItem,
        Skill1,
        Skill2,
        Skill3,
        Skill4,
        Skill5,
        Skill6,
        Item1,
        Item2,
        Item3,
        Item4,
        Item5,
        Item6,
    }
}
