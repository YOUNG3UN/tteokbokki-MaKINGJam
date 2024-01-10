using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroManager : MonoBehaviour
{

    public GameObject Outro;
    public GameObject Outro1;
    public GameObject Outro2;
    public GameObject Outro3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Jump")) { 
            if (GameManager.instance.lifeCount <= 3)
            {
                Outro1.gameObject.SetActive(true);
                Outro.gameObject.SetActive(false);
            }
            else if(GameManager.instance.lifeCount <= 6)
            {
                Outro2.gameObject.SetActive(true);
                Outro.gameObject.SetActive(false);
            }
            else
            {
                Outro3.gameObject.SetActive(true);
                Outro.gameObject.SetActive(false);
            }
        
        }*/
    }

    public void result()
    {
        if (GameManager.instance.lifeCount <= 3)
        {
            Outro1.gameObject.SetActive(true);
            Outro.gameObject.SetActive(false);
        }
        else if (GameManager.instance.lifeCount <= 6)
        {
            Outro2.gameObject.SetActive(true);
            Outro.gameObject.SetActive(false);
        }
        else
        {
            Outro3.gameObject.SetActive(true);
            Outro.gameObject.SetActive(false);
        }
    }
}
