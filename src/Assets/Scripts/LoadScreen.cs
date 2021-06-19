using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowButtons()
    {
        Debug.Log(StartButton);
        Debug.Log(ContinueButton);
        var seq = DOTween.Sequence();
        seq.Join(StartButton.GetComponent<Image>().DOColor(MainCanvas.RealColor, 3f))
            .Join(ContinueButton.GetComponent<Image>().DOColor(MainCanvas.RealColor, 3f));
        StartButton.SetActive(true);
        ContinueButton.SetActive(true);
    }
}
