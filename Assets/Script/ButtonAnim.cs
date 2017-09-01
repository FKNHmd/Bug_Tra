using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{

    // アニメーションさせるオブジェクト
    public GameObject[] animObjs;
    GameObject nowAnimObj;
    float rand;
    bool isActive = false;
    bool isSetAnim = false;
    float timeCount;
    

    public enum StateMar
    {
        Parent,
        Children,
    }

    public StateMar STATE;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (STATE)
        {
            case StateMar.Parent:
                {
                    if (!isSetAnim)
                    {
                        int animObjRand = Random.Range(0, animObjs.Length);
                        nowAnimObj = animObjs[animObjRand];
                        nowAnimObj.GetComponent<Animator>().SetBool("IsAnim", true);
                        rand = Random.Range(2.0f, 3.5f);
                        isSetAnim = true;
                    }
                    else
                    {
                        timeCount += Time.deltaTime;
                        if (timeCount > rand)
                        {
                            if (nowAnimObj.GetComponent<Animator>().GetBool("IsAnim") == false)
                            {
                                timeCount = 0;
                                isSetAnim = false;
                               
                                //isActive = true;
                            }
                        }
                    }
                    break;
                }
            case StateMar.Children:
                {

                    break;
                }
        }
    }

    public void AnimFalse()
    {
        GetComponent<Animator>().SetBool("IsAnim", false);
    }
}
