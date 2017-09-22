using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_04 : MonoBehaviour
{
    public InputField namae;
    public InputField namae2;
    public InputField syoukai;
    public InputField hanei;
    public InputField hanei2;
    public GameCtrl_PanelChange GP;
    public GameObject panelhoukoku;
    public HintManager _HintMar;

    public bool lasthint_flg = false;
    float lasthint_byou;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lasthint_flg)
        {
            lasthint_byou += Time.deltaTime;
            if (lasthint_byou > 15)
            {
                string naiyou = "名前や自己紹介を変えたり、ボタンを連続タップしたり、\nいろんな操作をしてバグを見つけよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
                lasthint_byou = 0;
            }
        }
    }

    void OnEnable()
    {
    }
    public void nyuryoku_Button()
    {
        hanei.text = namae.text + " " + namae2.text;
        hanei2.text = syoukai.text;
        if (!lasthint_flg)
        {
            string naiyou = "名前や自己紹介を変えたり、ボタンを連続タップしたり、\nいろんな操作をしてバグを見つけよう！";
            _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
            lasthint_flg = true;
        }
    }

    public void Houkoku_Button()
    {
        //GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
        panelhoukoku.SetActive(true);
    }
}
