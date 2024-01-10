using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public bool stepped = false;

    void Update()
    {
        if (transform.position.x < -8f && stepped == false)
        {
            PlayerController player = GameObject.Find("test_player").GetComponent<PlayerController>();
            player.Stun();
            stepped = true;
        }

        if (transform.position.x > 2f && stepped == true)
        {
            stepped = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            stepped = true;
        }
    }
}
