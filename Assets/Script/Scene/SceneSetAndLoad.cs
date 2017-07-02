using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

/*-----------------------------------------------------------------------
* 概要：シーンを管理するクラス
* 説明：シーン名をセットする/ロードする/その両方を行うメソッドに分かれる
* ----------------------------------------------------------------------*/
public class SceneSetAndLoad : MonoBehaviour{

    public string NextScene;    // 次のシーン名
    public float FadeTime;      // フェードする時間

    /*-----------------------------------------------------------------------
    * 概要：次に遷移するシーンをグローバル変数にセットする
    * 説明：シーン名をGlobal.NextSceneNameにセットする
    * ----------------------------------------------------------------------*/
    public void SetNextScene(){
        Global.NextSceneName = NextScene;
    }

    /*-----------------------------------------------------------------------
     * 概要：指定のシーンへ遷移する
     * 説明：Global.NextSceneNameを読み取って遷移
     * ----------------------------------------------------------------------*/
    public void LoadNextScene(){

        // シーン名がセットされていなかった場合
        if (Global.NextSceneName == ""){
            // エラーを出してとりあえずMenuシーンをセット
            Debug.LogError("SetNextSneceName：シーンがセットされませんでした。Menuに戻ります。");
            Global.NextSceneName = "Menu";
        }

        FadeManager.Instance.LoadLevel(NextScene, FadeTime);
    }

    /*-----------------------------------------------------------------------
     * 概要：シーンのセットと遷移を同時におこなう
     * 説明：SetNextSceneとLoadNextSceneを行う
     * ----------------------------------------------------------------------*/
    public void SetAndLoadNextScene(){
        SetNextScene();
        LoadNextScene();
    }
}


