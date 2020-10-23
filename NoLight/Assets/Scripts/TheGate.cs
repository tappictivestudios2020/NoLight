using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheGate : MonoBehaviour
{
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    bool p1Enter, p2Enter;
    private int nextLevel;

    private void Start()
    {
        p1Enter = false;
        p2Enter = false;
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            Debug.Log("Player 1 has enter");
            p1Enter = true;
        }else if (collision.gameObject.tag == "Player2")
        {
            Debug.Log("Player 2 has enter");
            p2Enter = true;
        }

        if(p1Enter == true && p2Enter == true)
        {
            Debug.Log("NExt LEvel");
            SceneManager.LoadScene(nextLevel);
        }
    }

}
