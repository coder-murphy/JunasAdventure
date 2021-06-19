using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainCanvas : MonoBehaviour
{
    /// <summary>
    /// 初始图片
    /// </summary>
    private GameObject _GameLoadingScreen = null;
    private GameObject _RootCanvas = null;
    private GameObject _GameStartScreen = null;

    public GameObject RootCanvas => _RootCanvas;
    public GameObject GameStartScreen => _GameStartScreen;

    /// <summary>
    /// 透明色
    /// </summary>
    public static Color TransparentColor => new Color(1.0f, 1.0f, 1.0f, 0);
    /// <summary>
    /// 实色
    /// </summary>
    public static Color RealColor => new Color(1.0f, 1.0f, 1.0f, 1.0f);

    private void Awake()
    {
        //Screen.SetResolution(1024, 768, false);
        _RootCanvas = GameObject.Find("Canvas");
        Object screen = Resources.Load("Prefabs/LoadingScreen");
        _GameLoadingScreen = Instantiate(screen) as GameObject;
        _GameLoadingScreen.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0f);
        _GameLoadingScreen.transform.SetParent(_RootCanvas.transform);
        RectTransform tran = _GameLoadingScreen.GetComponent<RectTransform>();
        tran.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, _RootCanvas.GetComponent<RectTransform>().rect.height);
        tran.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, _RootCanvas.GetComponent<RectTransform>().rect.width);

    }

    // Start is called before the first frame update
    void Start()
    {
        ShowSplashScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string stringDemo;


    private void OnGUI()
    {

    }

    void ShowSplashScreen()
    {
        var dOTween = DOTween.Sequence();
        Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Color colorFade = new Color(1.0f, 1.0f, 1.0f, 0f);
        dOTween.Append(_GameLoadingScreen.GetComponent<Image>().DOColor(color, 1.5f))
            .AppendInterval(1.0f)
            .Append(_GameLoadingScreen.GetComponent<Image>().DOColor(colorFade, 1.5f)).AppendCallback(() =>
        {
            Destroy(_GameLoadingScreen.gameObject);
            Object startScreen = Resources.Load("Prefabs/StartScreen");
            _GameStartScreen = Instantiate(startScreen) as GameObject;
            _GameStartScreen.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0f);
            _GameStartScreen.transform.SetParent(_RootCanvas.transform);
            RectTransform tranSScr = GameStartScreen.GetComponent<RectTransform>();
            tranSScr.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, _RootCanvas.GetComponent<RectTransform>().rect.height);
            tranSScr.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, _RootCanvas.GetComponent<RectTransform>().rect.width);
            GameStartScreen.GetComponent<Image>().DOColor(color, 1.5f);
            GameStartScreen.GetComponent<LoadScreen>().ShowButtons();
        });
        Debug.Log("加载完毕");
    }
}
