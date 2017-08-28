using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : MonoBehaviour
{
    // 元のオブジェクト
    public GameObject obj;
    int rand;
    float timeCount;
    bool createFlg = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (!createFlg)
        {
            rand = Random.Range(1,3);
            createFlg = true;
        }
        else
        {
            if (timeCount > rand)
            {
                GameObject newObj = Instantiate(obj)as GameObject;
                newObj.GetComponent<Animator>().enabled = true;
                newObj.transform.parent = transform;
                float scale = Random.Range(0.5f, 1.5f);
                newObj.transform.localScale = new Vector3(scale, scale,0);
                newObj.transform.localPosition = new Vector3(Random.Range(-360, 360), Random.Range(-300, 300), 0);

                timeCount = 0;
                createFlg = false;
            }
        }
    }
}
