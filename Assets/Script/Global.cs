using UnityEngine;
using System.Collections;

public class Global : SingletonMonoBehaviour<Global>
{

    /*---------------------------------------------------
     * 定数
     * --------------------------------------------------*/
    // シーン名
    public const string CnsSceneTraining_00 = "Game_Select";
    public const string CnsSceneTraining_01 = "Training_01";
    public const string CnsSceneTraining_02 = "Training_02";
    public const string CnsSceneTraining_03 = "Training_03";
    public const string CnsSceneTraining_04 = "Training_04";
    public const string CnsSceneTraining_05 = "Training_05";
    public const string CnsSceneTraining_06 = "Training_06";
    public const string CnsSceneTraining_07 = "Training_07";
    public const string CnsSceneTraining_08 = "Training_08";
    public const string CnsSceneTraining_09 = "Training_09";


    /*---------------------------------------------------
     * 変数
     * --------------------------------------------------*/
    public static string NextSceneName = "";    // 次に遷移するシーン名

    // シングルトン使用
    void Awake()
    {
        if (this != Instance){
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
