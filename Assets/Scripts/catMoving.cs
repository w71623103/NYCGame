using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class catMoving : MonoBehaviour
{
    public float movementSpeed = 0.05f;
    public float jumpSpeed = 8f;
    public Rigidbody2D playerRB;
    public bool isGrounded = false;
    public int score = 0;
    public GameObject staticRB;
    public GameObject dynamicRB;
    public TextMeshProUGUI scoreNum;
    public gamemanager gm;

    // Start is called before the first frame update
    // Equivalent of Create() in GameMaker
    void Start()
    {

        playerRB = GetComponent<Rigidbody2D>();
        playerRB.bodyType = staticRB.GetComponent<Rigidbody2D>().bodyType;

        //squareTransform = GetComponent<Transform>(); //this gets a reference to the Transform component on this same gameobject
        //squareTransform = transform;
    }

    // Update is called once per frame
    // Equivalent of Step() in GameMaker
    void FixedUpdate() //happens on a fixed time step
    {
        if (gm.gameStarted)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * movementSpeed);
                if (isGrounded)
                    GetComponent<Animator>().Play("catLeft");
                else
                    GetComponent<Animator>().Play("catJumpleft");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * movementSpeed);
                if (isGrounded)
                    GetComponent<Animator>().Play("catRight");
                else
                    GetComponent<Animator>().Play("catJumpright");
            }
            else
            {
                GetComponent<Animator>().Play("catStill");
            }
        }
        
    }

    void Update()
    {
        if (gm.gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isGrounded)
                {
                    playerRB.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                    //Vector2.up is a short way of writing new Vector2(0,-1);
                }

            }
        }
        scoreNum.text = score.ToString();
    }

    // This will get called when my player has collided with another object with a collider on it.
     void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "standable")
        {
            isGrounded = true;
        }
     }

     void OnCollisionExit2D(Collision2D collision)
     {
         if(collision.gameObject.tag == "standable")
        {
            isGrounded = false;
        }
     }

     void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.gameObject.tag == "collectable")
         {
            Debug.Log("Collected");
            score++;
            Destroy(collision.gameObject);
         }else if(collision.gameObject.tag == "bad-collectable")
         {
            Debug.Log("Collected");
            score--;
            Destroy(collision.gameObject);
         }
     }

}