using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_07 : MonoBehaviour
{

    //public GameCtrl_PanelChange GP;
    public GameObject PH;
    float hintTime = 0;
    bool hintFlg = false;

    public HintManager _HintMar;
    // Use this for initialization
    void Start()
    {
        string naiyou = "再生ボタンを押して\n音楽を再生してみよう！";
        _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
    }

    // Update is called once per frame
    void Update()
    {
        hintTime += Time.deltaTime;
        if (!hintFlg)
        {
            if (hintTime > 30)
            {
                string naiyou = "いろんな操作をしてバグを見つけよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                hintTime = 0;
                hintFlg = true;
            }
        }
        else
        {
            if (hintTime > 15)
            {
                string naiyou = "画面右上の「バグ報告」ボタンを押して、\n期待動作していないところを教えよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                hintTime = 0;
            }
        }

    }

    void OnEnable()
    {
    }

    public void Houkoku_Button()
    {
        //GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
        PH.SetActive(true);
    }
}
