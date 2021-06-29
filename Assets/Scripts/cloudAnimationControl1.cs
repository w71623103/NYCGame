using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudAnimationControl1 : MonoBehaviour
{

    public int animStart = 20;
    private int animCount = 0;
    private int animCount_dis = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(animCount <= animStart)
        {
            GetComponent<Animator>().Play("cloud_still");
            ++animCount;
        }else
        {
            if(animCount_dis <= 30)
            {
                GetComponent<Animator>().Play("cloud_disappear");
                ++animCount_dis;
            }
            else
            {
                animCount_dis = 0;
                animCount = 0;
            }
        }
    }
}
