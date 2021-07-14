using Assets.FDGameSDK.SQLite;
using Assets.Scripts.DataManager;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 获取游戏管理器的唯一实例
    /// </summary>
    public static GameManager Instance = null;

    /// <summary>
    /// 摄像机管理器
    /// </summary>
    public CameraManager CameraManager;

    private DataManager _DataManager = null;
    /// <summary>
    /// 数据管理器
    /// </summary>
    public DataManager DataManager
    {
        get
        {
            if (_DataManager == null)
                _DataManager = new DataManager();
            return _DataManager;
        }
    }

    /// <summary>
    /// 程序启动路径
    /// </summary>
    public static string StartUpPath => System.IO.Directory.GetCurrentDirectory();

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this;
            Init();
        }
    }


    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("关闭数据库服务");
            DataManager.CloseService();
        }
    }

    private void Init()
    {
        _RootCanvas = GameObject.Find("Canvas");
        DataManager.Init();
        //DataManager.AddCharInfo("GameEditor");
        DataManager.GetAllInfos("CharData");
        //Debug.Log(DataBasePath);
    }

    private GameObject _RootCanvas ;
    private GameObject _AreaTitle = null;

    /// <summary>
    /// 根据关卡类型读取关卡界面
    /// </summary>
    /// <param name="stageType"></param>
    /// <returns></returns>
    public void LoadStage(StageType stageType)
    {
        if(stageType == StageType.GloomForest)
        {
            _AreaTitle = Instantiate(Resources.Load("Prefabs/StageTitle")) as GameObject;
            _AreaTitle.SetActive(true);
            _AreaTitle.GetComponent<StageTitle>().TitleShowCompleted += () => Init();
            RectTransform tran = _AreaTitle.GetComponent<RectTransform>();
            tran.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, _RootCanvas.GetComponent<RectTransform>().rect.height);
            tran.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, _RootCanvas.GetComponent<RectTransform>().rect.width);
            _AreaTitle.transform.SetParent(_RootCanvas.transform);
            var title = _AreaTitle.GetComponent<StageTitle>();
            var seq = DOTween.Sequence();
            seq.Append(_RootCanvas.GetComponent<Image>().DOColor(new Color(0, 0, 0, 1), 1.0f))
                .Append(title.ShowTitle())
                .Append(title.FadeTitle())
                .Append(_RootCanvas.GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 1.0f)).
                AppendCallback(() => {
                    Debug.Log("loading完毕");
                    LoadStageScene(stageType);
                });
            ;
        }
    }

    /// <summary>
    /// 读取场景
    /// </summary>
    /// <param name="stageType"></param>
    private void LoadStageScene(StageType stageType)
    {
        if (stageType == StageType.GloomForest)
        {
            SceneManager.LoadScene("Scenes/ForestStageLv3", LoadSceneMode.Single); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region database


    #endregion
}

/// <summary>
/// 关卡类型
/// </summary>
public enum StageType
{
    GloomForest,
}
