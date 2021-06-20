using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject ContinueButton;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        AddEventHandler();
    }

    private void AddEventHandler()
    {
        StartButton.GetComponent<Button>().onClick.AddListener(() => NewGame());
        ContinueButton.GetComponent<Button>().onClick.AddListener(() => ContinueGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowButtons()
    {
        var seq = DOTween.Sequence();
        seq.Join(StartButton.GetComponent<Image>().DOColor(MainCanvas.RealColor, 3f))
            .Join(ContinueButton.GetComponent<Image>().DOColor(MainCanvas.RealColor, 3f));
        StartButton.SetActive(true);
        ContinueButton.SetActive(true);
    }

    private void NewGame()
    {
        SceneManager.LoadScene("Scenes/ForestStageLv3", LoadSceneMode.Single);
    }

    private void ContinueGame()
    {

    }
}
