using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_07 : MonoBehaviour
{

    //public GameCtrl_PanelChange GP;
    public GameObject PH;
    float hintTime = 0;
   public bool hintFlg = false;
    int count = 0;

    public HintManager _HintMar;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hintFlg && count ==0)
        {
            hintTime += Time.deltaTime;

            if (hintTime > 30)
            {
                string naiyou = "いろんな操作をしてバグを見つけよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                hintTime = 0;
                count++;
            }
        }
        else if (hintFlg && count != 0)
        {
            hintTime += Time.deltaTime;
            if (hintTime > 15)
            {
                string naiyou = "画面右上の「バグ報告」ボタンを押して、\n期待動作していないところを教えよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                hintTime = 0;
				hintFlg = false;
            }
        }

    }

    void OnEnable()
    {
		hintTime = 0;
		hintFlg = false;
		count = 0;
		string naiyou = "再生ボタンを押して\n音楽を再生してみよう！";
		_HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
    }

    public void Houkoku_Button()
    {
        //GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
        PH.SetActive(true);
    }
}
