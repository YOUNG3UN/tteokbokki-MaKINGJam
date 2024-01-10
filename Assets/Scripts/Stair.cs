using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stair : MonoBehaviour
{
    public float speed = 2f;

    public Transform[] stairs;

    private int currentStair;
    private bool[] isStairUp = new bool[12];

    //public GameObject btn;


    public GameObject coinprefab;
    GameObject[] coin = new GameObject[4];


    void Start()
    {
        Restart();
    }

    public void Restart()
    {
        //btn.SetActive(false);
        currentStair = 1;
        speed += (float)(GameManager.instance.lifeCount * 0.4);

        stairs[0].position = new Vector2(-6f, -3.5f);
        for (int i = 1; i < stairs.Length; i++)
        {
            isStairUp[i] = Random.Range(0, 2) == 0;
            if (isStairUp[i])
            {
                stairs[i].position = new Vector2(stairs[i - 1].position.x + 2, stairs[i - 1].position.y + 0.7f);                
            }
            else
            {
                stairs[i].position = new Vector2(stairs[i - 1].position.x + 2, stairs[i - 1].position.y - 0.7f);
            }
            HeightLimit(i);
        }

     

    }

    void Update()
    {

        NextStair();
    }

    void NextStair()
    {


        for (int i = 0; i < stairs.Length; i++)
        {
            stairs[i].transform.position += new Vector3(-2, 0, 0) * Time.deltaTime * speed;

        }


        for (int i = 0; i < stairs.Length; i++)
        {
            if (stairs[i].position.x < -10)
            {

                isStairUp[i] = Random.Range(0, 2) == 0;
                if (isStairUp[i])
                {
                    if (i == 0)
                    {
                        stairs[i].position = new Vector2(13.94117f, stairs[11].position.y + 0.7f);
                        //x값 임시
                      

                    }
                    else
                    {
                        stairs[i].position = new Vector2(13.94117f, stairs[i - 1].position.y + 0.7f);
                       
                    }
                    HeightLimit(i);
                    Addcoin(i);
                }
                else
                {
                    if (i == 0)
                    {
                        stairs[i].position = new Vector2(13.94117f, stairs[11].position.y - 0.7f);
                        
                    }
                    else
                    {
                        stairs[i].position = new Vector2(13.94117f, stairs[i - 1].position.y - 0.7f);
                       
                        
                    }
                    HeightLimit(i);
                    Addcoin(i);
                }
            }


        }
        currentStair++;
        if (currentStair >= 12) currentStair = 0;



    }


    public void Addcoin(int i)
    {
        float percent = 0.3f;
        float r_value = Random.Range(0.0f, 1.0f);
        if (r_value < percent)
        {
            GameObject spawncoin = Instantiate(coinprefab, stairs[i].transform);
            spawncoin.transform.position += new Vector3(0, 0.8f, 0);
            

        }
    }
        void HeightLimit(int i)
        {

            if (stairs[i].position.y > 0.1f)
            {
                stairs[i].position += new Vector3(0, -1.4f, 0);
            }


            if (stairs[i].position.y < -4.5)
            {
                stairs[i].position += new Vector3(0, 1.4f, 0);
            }
        }
   
}
