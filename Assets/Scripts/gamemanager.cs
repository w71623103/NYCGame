using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public GameObject fishcan;
    public GameObject surstormming;
    public GameObject spawn_pos1;
    public GameObject spawn_pos2;
    public GameObject spawn_pos3;
    public GameObject spawn_pos4;
    public float timeBetweenSpawn1 = 5f;
    public float timeBetweenSpawn2 = 10f;
    public float timeBetweenSpawn3 = 15f;
    public float timeBetweenSpawn4 = 20f;
    public float timer = 0f;
    public bool time1spawned =false;
    public bool time2spawned =false;
    public bool time3spawned =false;
    public int GOB1 = 0;
    public int GOB2 = 0;
    public int GOB3 = 0;
    public int GOB4 = 0;
    public float posRand1 = 0f;
    public float posRand2 = 0f;
    public float posRand3 = 0f;
    public float posRand4 = 0f;
    public catMoving cat;
    public Button startButton;

    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GOB1 = Random.Range(1, 100);
        GOB2 = Random.Range(1, 100);
        GOB3 = Random.Range(1, 100);
        GOB4 = Random.Range(1, 100);

        posRand1 = Random.Range(-10f, 10f);
        posRand2 = Random.Range(-10f, 10f);
        posRand3 = Random.Range(-10f, 10f);
        posRand4 = Random.Range(-10f, 10f);


        if (gameStarted)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenSpawn4)
            {
                spawn_pos1.transform.Translate(Vector3.left * posRand1);
                spawn_pos2.transform.Translate(Vector3.left * posRand2);
                spawn_pos3.transform.Translate(Vector3.left * posRand3);
                spawn_pos4.transform.Translate(Vector3.left * posRand4);

                timer = 0f;
                if (GOB1 >= 40)
                {
                    GameObject newBall1 = Instantiate(fishcan, spawn_pos1.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall1 = Instantiate(surstormming, spawn_pos1.transform.position, Quaternion.identity);
                }
                if (GOB2 >= 90)
                {
                    GameObject newBall2 = Instantiate(fishcan, spawn_pos2.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall2 = Instantiate(surstormming, spawn_pos2.transform.position, Quaternion.identity);
                }

                if (GOB3 >= 50)
                {
                    GameObject newBall3 = Instantiate(fishcan, spawn_pos3.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall3 = Instantiate(surstormming, spawn_pos3.transform.position, Quaternion.identity);
                }


                if (GOB4 >= 20)
                {
                    GameObject newBall4 = Instantiate(fishcan, spawn_pos4.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall4 = Instantiate(surstormming, spawn_pos4.transform.position, Quaternion.identity);
                }
                time1spawned = false;
                time2spawned = false;
                time3spawned = false;

            }
            else if (timer >= timeBetweenSpawn3 && !time3spawned)
            {
                spawn_pos1.transform.Translate(Vector3.left * posRand1);
                spawn_pos2.transform.Translate(Vector3.left * posRand2);
                spawn_pos4.transform.Translate(Vector3.left * posRand4);

                time3spawned = true;
                if (GOB1 >= 70)
                {
                    GameObject newBall1 = Instantiate(fishcan, spawn_pos1.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall1 = Instantiate(surstormming, spawn_pos1.transform.position, Quaternion.identity);
                }

                if (GOB2 >= 50)
                {
                    GameObject newBall2 = Instantiate(fishcan, spawn_pos2.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall2 = Instantiate(surstormming, spawn_pos2.transform.position, Quaternion.identity);
                }

                if (GOB4 >= 50)
                {
                    GameObject newBall4 = Instantiate(fishcan, spawn_pos4.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall4 = Instantiate(surstormming, spawn_pos4.transform.position, Quaternion.identity);
                }
            }
            else if (timer >= timeBetweenSpawn2 && !time2spawned)
            {
                spawn_pos1.transform.Translate(Vector3.left * posRand1);
                spawn_pos4.transform.Translate(Vector3.left * posRand4);

                time2spawned = true;
                if (GOB1 >= 30)
                {
                    GameObject newBall1 = Instantiate(fishcan, spawn_pos1.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall1 = Instantiate(surstormming, spawn_pos1.transform.position, Quaternion.identity);
                }
                if (GOB4 >= 50)
                {
                    GameObject newBall4 = Instantiate(fishcan, spawn_pos4.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall4 = Instantiate(surstormming, spawn_pos4.transform.position, Quaternion.identity);
                }
            }
            else if (timer >= timeBetweenSpawn1 && !time1spawned)
            {
                spawn_pos2.transform.Translate(Vector3.left * posRand2);

                time1spawned = true;
                if (GOB2 >= 80)
                {
                    GameObject newBall2 = Instantiate(fishcan, spawn_pos2.transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject newBall2 = Instantiate(surstormming, spawn_pos2.transform.position, Quaternion.identity);
                }
            }
        }
    }

    public void StartTheGame() 
    {
        if (!gameStarted)
        {
            gameStarted = true;
            cat.playerRB.bodyType = cat.dynamicRB.GetComponent<Rigidbody2D>().bodyType;
            Destroy(startButton.gameObject);
            timer = 0;
        }
    }
}
