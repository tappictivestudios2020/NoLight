using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDeath : MonoBehaviour
{
    bool isDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2"
    || collision.gameObject.tag == "Player1" && collision.gameObject.tag == "Player2")
        {
            isDead = true;
            DeathMenu.Instance.gameObject.SetActive(true);
        }
    }
}
