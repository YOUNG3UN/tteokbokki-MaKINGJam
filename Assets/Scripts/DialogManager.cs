using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public Text talkText;
    public string [] textArray = {"저 대현동 떡볶이 먹고싶어요", "엥? 여기 떡볶이 없는데?", 
        "왜 없어요? 여기 천국 맞아요? 없으면 어떻게 먹는데요?",
        "어.. 현생가야해",
        "으아ㅏㅏ아아ㅏ아아ㅏㅏ 대현동 떡볶이가 없는 곳은 지옥이야!! 나 보내줘요!!",
        "진짜 천국을 거부한다고?? 보내줄테니까 대신 저번 생보다 떡볶이를 더 먹지 않으면 다시는 떡볶이를 못먹게 될 줄 알아"};
    private int i = 0;
    public GameObject InGame;
    public GameObject Intro;
    public GameObject start;
    public GameObject GodImage;
    public GameObject PlayerImage;
    public GameObject Outro;
    public GameObject MidGame;

    public GameObject Outro1;
    public GameObject Outro2;
    public GameObject Outro3;

    AudioSource introAudioSource;

    void Awake()
    {
        i = 0;
        start.gameObject.SetActive(true);
        InGame.gameObject.SetActive(false);
        Intro.gameObject.SetActive(false);
        Outro.gameObject.SetActive(false);
        MidGame.gameObject.SetActive(false);

        Outro1.gameObject.SetActive(false);
        Outro2.gameObject.SetActive(false);
        Outro3.gameObject.SetActive(false);
    }

    void Start()
    {
        introAudioSource = GetComponent<AudioSource>();
        introAudioSource.Play();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (i == textArray.Length)
            {
                InGame.gameObject.SetActive(true);
                Intro.gameObject.SetActive(false);
                MidGame.gameObject.SetActive(false);
                introAudioSource.Stop();
            }
            else
            {
                if (i % 2 == 0)
                {
                    GodImage.gameObject.SetActive(false);
                    PlayerImage.gameObject.SetActive(true);
                }
                else
                {
                    GodImage.gameObject.SetActive(true);
                    PlayerImage.gameObject.SetActive(false);
                }
                talkText.text = textArray[i];
                i++;
            }
        }
    }

    
}
