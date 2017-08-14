using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetPopupElement_02 : MonoBehaviour {

    // ----------変数----------
    public Text Popuptitle;         // ポップアップのタイトル
    public Text PopupDescription;   // ポップアップ内の説明

    public void SetPopup() {

        //*** この辺で押したボタンによってポップアップに表示させる文言を変える処理。DB読み込み。

        Popuptitle.text = "タイトルですよおおおぉぉ";
        PopupDescription.text = "説明文ですよおおおおおおおおおお\nおおおおおおおおおおおおおおおおお\n" +
            "おおおおおおおおおおおおおおおおお\nおおおおおおおおおおおおおおおおお\nおおおおおおおおおおおおおおおおお\n" +
            "おおおおおおおおおおおおおおおおお\nおおおおおおおおおおおおおおおおお";

    }
}
