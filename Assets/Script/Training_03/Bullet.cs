using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    // 敵を格納
    GameObject enemyObj;
    // 子を格納
    List<Transform> createEnemy = new List<Transform>();

    // 移動量
    public Vector3 _velocty;

    // 参照
    Rigidbody _rigid;
    GameManager_03 _gameMar;
    SoundManager_Tr03 _SoundMar;

    // 生存時間
    float lifeTime;

	// Use this for initialization
	void Start () {
        _rigid = GetComponent<Rigidbody>();
        _gameMar = GameObject.Find("GameManager").GetComponent<GameManager_03>();
        _SoundMar = GameObject.Find("SoundManager").GetComponent<SoundManager_Tr03>();

    }

    // Update is called once per frame
    void FixedUpdate() {
        //TestRay();
        Vector3 v = _rigid.velocity;
        v += transform.forward * (Time.deltaTime * 100);
        _rigid.velocity = v;

        lifeTime += Time.deltaTime;
        if(lifeTime > 2)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject != null)
        {
            if (coll.gameObject.tag == "Enemy")
            {
                _SoundMar.SEOnPlay(1);
                enemyObj = coll.transform.gameObject;
                Vector3 pos = enemyObj.transform.position;
                Vector3 size = enemyObj.transform.localScale;
                GameObject parentObj = new GameObject();

                if (size.x > 1)
                {
                    _gameMar.scoreNum += 100;
                    _gameMar.scoreText.GetComponent<Text>().text = "SCORE:" + _gameMar.scoreNum;
                    parentObj.transform.position = enemyObj.transform.position;
                    enemyObj.GetComponent<Collider>().enabled = false;
                    for (int x = 0; x < 2; x++)
                    {
                        for (int y = 0; y < 2; y++)
                        {
                            for (int z = 0; z < 2; z++)
                            {
                                // 取得したオブジェクトを生成
                                GameObject createObj = Instantiate(enemyObj, Vector3.zero, Quaternion.identity) as GameObject;
                                // 生成したものを格納
                                createEnemy.Add(createObj.transform);
                                // 親を指定
                                createObj.transform.parent = parentObj.transform;
                                // 大きさを元の半分にする
                                createObj.transform.localScale = size / 2;
                                // 表示生成位置を設定
                                createObj.transform.position = new Vector3(
                                    (pos.x - (createObj.transform.localScale.x / 2)) + (createObj.transform.localScale.x * x),
                                     (pos.y - (createObj.transform.localScale.y / 2)) + (createObj.transform.localScale.y * y),
                                     (pos.z - (createObj.transform.localScale.z / 2)) + (createObj.transform.localScale.z * z));
                                // 当たり判定を戻す
                                createObj.GetComponent<Collider>().enabled = true;

                                // 当たった威力を与える(弾のVeloctyを加える)
                                Vector3 v = transform.GetComponent<Rigidbody>().velocity;
                                v.x = (v.x + Random.Range(-v.x, v.x));
                                v.y = (v.y + Random.Range(-v.y, v.y));
                                v.z = (v.z + Random.Range(-v.z, v.z));

                                createObj.GetComponent<Rigidbody>().velocity = v + (transform.forward * 0.1f);

                            }
                        }
                    }
                    // 最後の処理
                    parentObj.transform.eulerAngles = enemyObj.transform.eulerAngles;

                    // 子に設定したEnemyタグの親を消す
                    for (int i = 0; i < createEnemy.Count; i++)
                    {
                        createEnemy[i].transform.parent = null;
                    }
                    // 処理の終わりに中身を空にする
                    createEnemy.Clear();
                    Destroy(parentObj);
                    Destroy(enemyObj);
                }
                else
                {
                    _gameMar.scoreNum += 150;
                    _gameMar.scoreText.GetComponent<Text>().text = "SCORE:" + _gameMar.scoreNum;
                    Instantiate(_gameMar.boxEffect, enemyObj.transform.position,Quaternion.Euler(new Vector3(-90,0,0)));
                    Destroy(enemyObj);
                }
            }
            Destroy(this.gameObject);
        }
    }

    void TestRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        // クリックして離した時に判定
        if (Input.GetMouseButtonDown(0))
        {
            // レイを飛ばして当たれば判定
            if (Physics.Raycast(ray, out hit) && hit.transform != null)
            {
                if (hit.transform.tag == "Enemy")
                {
                    enemyObj = hit.transform.gameObject;
                    Vector3 pos = enemyObj.transform.position;
                    Vector3 size = enemyObj.transform.localScale;
                    if (size.x > 1)
                    {
                        enemyObj.GetComponent<Collider>().enabled = false;
                        for (int x = 0; x < 2; x++)
                        {
                            for (int y = 0; y < 2; y++)
                            {
                                for (int z = 0; z < 2; z++)
                                {
                                    // 取得したオブジェクトを生成
                                    GameObject createObj = Instantiate(enemyObj, Vector3.zero, Quaternion.identity) as GameObject;
                                    createObj.transform.localScale = size / 2;
                                    createObj.transform.position = new Vector3(
                                        (pos.x - (createObj.transform.localScale.x / 2)) + (createObj.transform.localScale.x * x),
                                         (pos.y - (createObj.transform.localScale.y / 2)) + (createObj.transform.localScale.y * y),
                                         (pos.z - (createObj.transform.localScale.z / 2)) + (createObj.transform.localScale.z * z));
                                    createObj.GetComponent<Collider>().enabled = true;

                                }
                            }
                        }
                        Destroy(enemyObj);
                    }
                }
            }
        }
    }
}
