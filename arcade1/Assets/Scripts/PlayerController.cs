using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;            // 위아래 이동 속력
    private float stunnedTime;          // 스턴이 걸린 시점

    public AudioClip up;
    public AudioClip down;
    public AudioClip eat;
    public AudioClip stun;

    private Rigidbody2D playerRigidbody;
    public Animator anim;
    private AudioSource playerAudio;
    private float moveY;

    public List<GameObject> FoundObjects;
    public float shortDist;
    public GameObject square;

    public float distance = 0.7f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 상하 이동
        moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //transform.position = new Vector2(transform.position.x, transform.position.y + moveY);

        // 효과음
        /*if (Input.GetButtonDown("Vertical"))
        {
            if(Input.GetAxis("Vertical")>0)
            {
                playerAudio.clip = up;
                playerAudio.Play();
            }
            else if(Input.GetAxis("Vertical") < 0)
            {
                playerAudio.clip = down;
                playerAudio.Play();
            }
        }*/
        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.position += Vector3.up * distance;

            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                transform.position += Vector3.down * distance;
            }
        }

        // 계단 오르내리는 애니메이션
        if (moveY > 0)
        {
            anim.SetBool("goingUp", true);
        }
        else if (moveY < 0)
        {
            anim.SetBool("goingDown", true);
        }
        else
        {
            anim.SetBool("goingUp", false);
            anim.SetBool("goingDown", false);
        }

        // 스턴이 걸린 시점에서 stunTime 이상 시간이 흘렀다면
        if (GameManager.instance.rTime <= stunnedTime - GameManager.instance.stunTime)
        // 현재 남은 시간 <= 스턴 걸린 시점 - 스턴 지속 시간
        {
            BG_Scroll scroll = GameObject.Find("Quad").GetComponent<BG_Scroll>();
            Stair stair = GameObject.Find("Stair_Spawn").GetComponent<Stair>();
            // 원래 상태로 돌아옴
            anim.ResetTrigger("isStunned");
            anim.SetTrigger("Stand");
            scroll.speed = (float)0.5;
            stair.speed = (float)1;
            speed = 8f;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "item")
        {
            playerAudio.clip = eat;
            playerAudio.Play();

            // 떡볶이 획득 시 점수 추가
            GameManager.instance.AddScore(1);

            // 떡볶이 오브젝트 비활성화
            other.gameObject.SetActive(false);

        }
    }

    public void Stun()
    {
        // 효과음
        playerAudio.clip = stun;
        playerAudio.Play();

        // 스턴이 걸린 시점을 현재 시점으로 갱신
        stunnedTime = GameManager.instance.rTime;

        // 화면 정지
        BG_Scroll scroll = GameObject.Find("Quad").GetComponent<BG_Scroll>();
        scroll.speed = 0;

        // 계단 정지
        Stair stair = GameObject.Find("Stair_Spawn").GetComponent<Stair>();
        stair.speed = 0;

        // 플레이어 정지 & 리스폰
        transform.position = new Vector2(transform.position.x, FindNearestObject().transform.position.y + 1.8f);
        anim.ResetTrigger("Stand");
        anim.SetTrigger("isStunned");
        speed = 0;

    }

    private GameObject FindNearestObject()
    {
        shortDist = 1000f;
        // 탐색할 오브젝트 목록을 List로 저장
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("stair"));

        square = FoundObjects[0];

        foreach(GameObject found in FoundObjects)
        {
            float dist = Vector2.Distance(transform.position, found.transform.position);
            if(dist < shortDist)
            {
                square = found;
                shortDist = dist;
            }
        }
        return square;
    }
}