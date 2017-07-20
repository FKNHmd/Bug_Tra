using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    // 表示を操作するオブジェクトを格納
    public GameObject hideObject, activeObject;

    GameManager _GameMar;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 表示を操作
    public void HideSwitch()
    {
        hideObject.SetActive(false);
        activeObject.SetActive(true);
    }
    // ベストスコアの表示
    public void BestScore()
    {
        activeObject.SetActive(true);
        _GameMar = GameObject.Find("GameManager").GetComponent<GameManager>();
        _GameMar.BestScore();
        hideObject.SetActive(false);
    }

    // 一時停止
    public void StopButton()
    {
        if (hideObject.activeSelf)
        {
            hideObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            hideObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // バグを見つけた際
    public void BagCheck()
    {
        _GameMar = GameObject.Find("GameManager").GetComponent<GameManager>();
        Time.timeScale = 0;
        // 半透明の画像を表示

        if (_GameMar.isBagSET)
        {
            // バグが発生した際に見えないボタンを押されたらクリアにする

        }
        else
        {
            // 違ったらゲームオーバー

        }
    }
}
