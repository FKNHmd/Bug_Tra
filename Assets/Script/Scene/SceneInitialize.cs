using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneInitialize : SingletonMonoBehaviour<SceneInitialize> {

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log(arg0.name);

        if (arg0.name == "Menu") {
            AudioManager.Instance.TimeToFade = 0f;
            AudioManager.Instance.CrossFadeRatio = 0f;
            AudioManager.Instance.PlayBGM("bgm_maoudamashii_neorock72");
        }

        if (arg0.name == "Training") {
            //AudioManager.Instance.TimeToFade = 1.0f;
            //AudioManager.Instance.CrossFadeRatio = 0.5f;
            //AudioManager.Instance.PlayBGM("ikusa_japan2");
        }
    }
}
