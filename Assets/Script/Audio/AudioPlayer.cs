using UnityEngine;
using System.Collections;

/*-----------------------------------------------------------------------
* 概要：Audioを再生するクラス
* 説明：設定されたSE/BGM名をAudioManagerに渡して鳴らす
* ----------------------------------------------------------------------*/
public class AudioPlayer : MonoBehaviour
{
    public string SEName;   // 再生するSE名
    public string BGMName;  // 再生するBGM名

    [Range(0f, 1f)]
    public float TargetVolume = 1.0f;
    public float TimeToFade = 2.0f;
    public float CrossFadeRatio = 1.0f;

    public void PlaySE()
    {
        if (SEName == ""){
            Debug.LogError("AudioPlayer.PlaySE：SE名がセットされていません");
        }else {
            AudioManager.Instance.PlaySE(SEName);
        }
    }

    public void PlayBGM()
    {
        if (BGMName == ""){
            Debug.LogError("AudioPlayer.PlayBGM：BGM名がセットされていません");
        }else{
            AudioManager.Instance.TargetVolume = TargetVolume;
            AudioManager.Instance.TimeToFade = TimeToFade;
            AudioManager.Instance.CrossFadeRatio = CrossFadeRatio;
            AudioManager.Instance.PlayBGM(BGMName);
        }
    }
}