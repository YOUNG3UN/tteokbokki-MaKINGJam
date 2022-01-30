using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidGameManager : MonoBehaviour
{
    //public Text midText1;
    public Text life;
    public GameObject mental1;
    public GameObject mental2;

    public GameObject MidGame;
    public GameObject Ingame;

    AudioSource midAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        midAudioSource = GetComponent<AudioSource>();
        midAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        life.text = "" + GameManager.instance.lifeCount;

        if (GameManager.instance.stunDiff > 3f)
        {
            mental1.gameObject.SetActive(false);
            mental2.gameObject.SetActive(false);
        }
        //midText1.text = "고난이 있어야 인생이지 (스턴시간 증가)";
        else if(GameManager.instance.stunDiff == 3f)
        {
            mental1.gameObject.SetActive(true);
            mental2.gameObject.SetActive(false);
        }
        else
        {
            mental1.gameObject.SetActive(true);
            mental2.gameObject.SetActive(true);
        }
        //midText1.text = "실패할 때 다시 일어나기 편하게 만들어줄게 (스턴 시간 감소)";

        if (Input.GetButtonDown("Jump"))
        {
            midAudioSource.Stop();
            MidGame.gameObject.SetActive(false);
            Ingame.gameObject.SetActive(true);
            //GameManager.instance.Update();
        }
    }

}
