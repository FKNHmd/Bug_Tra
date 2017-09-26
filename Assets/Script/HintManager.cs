using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    // クロスちゃんの画像を変える
    public GameObject[] crossTyan;
    // 時間
    public float timeCount = 0;
    float hintSETTime = 0;
    // テキスト内容
    string hintText;
    // 表示フラグ
    bool isHideFlg = false;
    // テキストを変えるオブジェクト
    public Text textObject;
    // 生成するオブジェスト
    public GameObject hintPanel;
    [SerializeField]
    public List<GameObject> hintObjects = new List<GameObject>();
    // 表示中のオブジェクトを確認する
    public bool isActiveHint = false;
    // 要素数が多くなった場合の処理
    bool isListOver = false;
    // Activeじゃなくなったオブジェクト
    public GameObject hideObject;

    // テスト作成用
    public bool isCreate = false;
    int createCount = 0;

    public enum State
    {
        Parent,
        Child,
    }
    public State HintState;

    public enum FaceState
    {
        Egao,
        ManmenEgao,
        Syobon,
        Gakkari,
    }
    public FaceState FACESTATE;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (HintState)
        {
            case State.Parent:
                {
                    // デバッグ用の処理*************************************************
                    //if (Input.GetKeyDown(KeyCode.A))
                    //{
                    //    isCreate = true;
                    //}
                    //if (isCreate)
                    //{
                    //    HintParent("テスト", 2, FaceState.Syobon);
                    //    isCreate = false;
                    //}

                    break;
                }
            case State.Child:
                {
                    if(hideObject != null)
                    {
                        if (!hideObject.activeSelf)
                        {
                            ObjectDes();
                            return;
                        }
                    }
                    if (isHideFlg)
                    {
                        GetComponent<Animator>().SetBool("HintFlg", true);
                        timeCount += Time.deltaTime;

                        if (hintSETTime < timeCount)
                        {
                            isHideFlg = false;
                            GetComponent<Animator>().SetBool("HintFlg", false);
                            //if (transform.parent.GetComponent<HintManager>().hintObjects.Contains(transform.gameObject))
                            //{
                            //    transform.parent.GetComponent<HintManager>().hintObjects.Remove(transform.gameObject);
                            //}
                        }
                    }
                    else
                    {
                        timeCount = 0;
                    }
                    break;
                }
        }

    }

    // テキストの内容を変更し、表示時間を指定する
    public void HintParent(string hintNaiyou, float hintTime,FaceState crossFace)
    {
        isActiveHint = false;
        // オブジェクトを生成
        GameObject createHint = Instantiate(hintPanel);
        createHint.transform.SetParent(transform, false);
        createHint.SetActive(true);
        //createHint.transform.parent = transform;
        createHint.transform.localPosition = hintPanel.transform.localPosition;
        createHint.GetComponent<HintManager>().Hint(hintNaiyou, hintTime, crossFace);

        //// 順番の要素が空なら入れる
        //if (hintObjects[createCount] == null)
        //{
        //    createHint.transform.localPosition = new Vector3(
        //                  0,
        //                  createCount * (-100),
        //                 0);
        //    hintObjects[createCount] = createHint;
        //    createCount++;
        //}
        //// 要素があるのなら空のものを探す
        //else
        //{
        int num = 0;
        while (!isActiveHint)
        {
            // 空の要素があった
            if (hintObjects[num] == null)
            {
                // 位置を調整
                createHint.transform.localPosition = new Vector3(
                   0,
                   (num * (-50)) + hintPanel.transform.localPosition.y,
                  0);
                hintObjects[num] = createHint;
                createCount = 0;
                isActiveHint = true;
            }
            // 空の要素がなかった
            else
            {
                num++;
                // 空の要素が無かったら入れ替える
                if (num > hintObjects.Count - 1)
                {
                    createHint.transform.localPosition = new Vector3(
                         0,
                         (createCount * (-50)) + hintPanel.transform.localPosition.y,
                        0);
                    hintObjects[createCount] = createHint;
                    createCount++;
                    isActiveHint = true;
                }
            }
        }
        // }

        if (createCount == 3)
        {
            createCount = 0;
        }
    }
    public void Hint(string hintNaiyou, float hintTime,FaceState crossFace)
    {
        // アニメーションを起動
        isHideFlg = true;
        textObject.text = "" + hintNaiyou;
        hintSETTime = hintTime;

        for(int i = 0; i < crossTyan.Length; i++)
        {
            crossTyan[i].SetActive(false);
        }

        switch (crossFace)
        {
            case FaceState.Egao:
                {
                    crossTyan[0].SetActive(true);
                    break;
                }
            case FaceState.ManmenEgao:
                {
                    crossTyan[1].SetActive(true);
                    break;
                }
            case FaceState.Syobon:
                {
                    crossTyan[2].SetActive(true);
                    break;
                }
            case FaceState.Gakkari:
                {
                    crossTyan[3].SetActive(true);
                    break;
                }
        }
    }

    public void ObjectDes()
    {
        Destroy(transform.gameObject);
    }
}
