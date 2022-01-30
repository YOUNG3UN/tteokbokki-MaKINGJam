using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public PlayerController player;

    public Text scoreText;      // 현재 점수 텍스트
    public Text recordText;     // 최고 기록 텍스트
    public Text timeText;       // 제한 시간 텍스트 
    public Text lifeCountText;  // 인생 회차 텍스트

    public float stunTime = 3f;        // 기본 스턴 시간
    public float stunDiff = 0f;

    public float rTime = 10f;
    public int score = 0;      // 게임 점수

    private int bestscore = 0;  // 최고 기록
    public int lifeCount = 1;  // 인생 회차

    public GameObject MidGame;
    public GameObject Outro;
    public GameObject Ingame;

    private string outro;
    public Text outroText1;
    public Text outroText2;

    AudioSource inGameAudioSource;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        
    }

    void Start()
    {
        inGameAudioSource = GetComponent<AudioSource>();
        inGameAudioSource.Play();

        //player.transform.GetChild(0).animation.Stop();
        //GameObject.Anim(GameObject.animation[anim].clip, 0);

        // 원래 상태로 돌아옴
        BG_Scroll scroll = GameObject.Find("Quad").GetComponent<BG_Scroll>();
        Stair stair = GameObject.Find("Stair_Spawn").GetComponent<Stair>();
        PlayerController player = GameObject.Find("test_player").GetComponent<PlayerController>();
        player.anim.ResetTrigger("isStunned");
        player.anim.SetTrigger("Stand");
        scroll.speed = (float)0.5;
        //stair.speed = (float)1;
        player.speed = 8f;

        rTime = 40f;
        recordText.text = "전생 기록 " + bestscore;
        lifeCountText.text = "인생 회차 " + lifeCount;

        // 2회차부터 스턴 시간 증가 또는 감소 & 점수 베네핏 또는 핸디캡
        if (lifeCount != 1)
        {

            // 스턴 시간 감소
            stunDiff = Random.Range(-3f, 3f);
            stunTime += stunDiff;
            // 스턴 시간 증가
            //stunTime = Random.Range(3f, 5f);
            // 점수 베네핏
            score = 0;
            // 점수 핸디캡
            //score = Random.Range(-5, -1);
            scoreText.text = "" + score;

            // 신 등장

            inGameAudioSource.Stop();
            MidGame.gameObject.SetActive(true);
            Ingame.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        // 제한 시간 표시
        rTime -= Time.deltaTime;
        if (rTime < 0)
        {
            rTime = 0;
        }
        timeText.text = "남은 시간 " + Mathf.Round(rTime);

        // 제한 시간 경과 후 점수 비교
        if (rTime == 0)
        {
            // 최고 기록 경신 성공
            if (score > bestscore)
            {
                bestscore = score;
                lifeCount++;
                Start();
                //Ingame.gameObject.SetActive(true);
                // 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작
                //if(Input.GetMouseButtonDown(0)) 
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            // 최고 기록 경신 실패
            else
            {
                // 아웃트로 엔딩 진행
                // SceneManager.LoadScene();
                outroText1.text = lifeCount + "회차 동안 보여준 떡볶이에 대한 너의 진심...나도 떡볶이 영업당해서 배달시켰는데 같이 먹으실?";
                //outroText2.text = "기다려봐… 나도 떡볶이 영업당해서 천국에 " + outro + "떡볶이를 데리고 왔어어억!";
                Ingame.gameObject.SetActive(false);
                Outro.gameObject.SetActive(true);
            }
        }
    }

    // 떡볶이 획득 시 점수 추가
    public void AddScore(int newScore)
    {
        score += newScore;
        scoreText.text = "" + score;
    }

}
