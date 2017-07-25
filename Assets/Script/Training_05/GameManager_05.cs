using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_05 : MonoBehaviour {

   public bool isBugCheck = false;

    public GameObject gameClaer,bugUI;

    // Use this for initialization
    void Start () {
        // 自動回転可能にする
        Screen.orientation = ScreenOrientation.AutoRotation;
        //スマホの左側が下になります
        Screen.autorotateToLandscapeLeft = true;
        //スマホの右側が下になります
        Screen.autorotateToLandscapeRight = true;
        //スマホの下が下になります
        Screen.autorotateToPortrait = true;
        //スマホの上が上になります
        Screen.autorotateToPortraitUpsideDown = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    // バグを見つけた際の処理
    void BugCheck()
    {
        if (isBugCheck)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // レイを飛ばして当たれば判定
                if (hit.collider != null)
                {
                    // 当たったのがバグの画像、かつバグがセット中であればゲームクリアー
                    if (hit.collider.name == "BugImage")
                    {
                        // ゲームクリアー
                        gameClaer.SetActive(true);
                        Screen.orientation = ScreenOrientation.Portrait;
                    }
                }
            }
        }
    }
    private void OnDisable()
    {
        // スマホの縦画面のみを許可
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // バグボタン
    public void BugCheckButton()
    {
        if (bugUI.activeSelf)
        {
            isBugCheck = false;
            bugUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            isBugCheck = true;
            bugUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
