using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetPopupElement : MonoBehaviour {

    // ----------変数----------
    public Text Popuptitle;         // ポップアップのタイトル
    public Text PopupDescription;   // ポップアップ内の説明

    public void SetPopup() {

        //*** この辺で押したボタンによってポップアップに表示させる文言を変える処理。DB読み込み。

        Popuptitle.text = "Q1の問題のタイトルだよ";
        PopupDescription.text = "Q1の問題の説明文だよ XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

    }
}
