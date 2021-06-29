using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    public bool isGrounded = false;
    public bool gameStartedcollectable = false;
    public float disappearLag = 3f;
    //public Rigidbody2D fishcanRB;
    //public GameObject staticRB;
    //public GameObject dynamicRB;

    //public gamemanager gm;
    // Start is called before the first frame update
    void Start()
    {
        //fishcanRB = GetComponent<Rigidbody2D>();
        //fishcanRB.bodyType = staticRB.GetComponent<Rigidbody2D>().bodyType;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gm.gameStarted)
        {
            fishcanRB.bodyType = dynamicRB.GetComponent<Rigidbody2D>().bodyType;
        }
        */
        if (isGrounded)
        {
            Destroy(gameObject, disappearLag);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "standable" || collision.gameObject.tag == "collectable")
        {
            isGrounded = true;
        }
     }
}
