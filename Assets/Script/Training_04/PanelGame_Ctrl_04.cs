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
	public GameObject Nyuuryokusitene;

    public bool lasthint_flg = false;
    float lasthint_byou;
    int count = 0;

    // Use this for initialization
    void Start()
    {      
        string naiyou = "名前と自己紹介を書いて\n入力ボタンをタップしよう！";
        _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);

    }

    // Update is called once per frame
    void Update()
    {
        if (lasthint_flg)
        {
            lasthint_byou += Time.deltaTime;
            if (lasthint_byou > 15)
            {
                string naiyou = "画面右上の「バグ報告」ボタンを押して、\n変な表示になっているところを教えよう！";
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
		/* 姓名自己紹介の入力チェック */
		if ((namae.text == "") || (namae2.text == "") || (syoukai.text == "")) {
			Nyuuryokusitene.SetActive (true);
			return;
		}

        hanei.text = namae.text + " " + namae2.text;
        hanei2.text = syoukai.text;
        hanei2.GetComponent<RectTransform>().sizeDelta = new Vector2(
            syoukai.preferredWidth,
            165);
        if(syoukai.preferredWidth > 745)
        {
            lasthint_flg = true;
        }
        if (!lasthint_flg && count == 0)
        {
            string naiyou = "名前や自己紹介を変えたり、ボタンを連続タップしたり、\nいろんな操作をしてバグを見つけよう！";
            _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
            count++;
        }
    }

    public void Houkoku_Button()
    {
        //GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
        panelhoukoku.SetActive(true);
    }
}
