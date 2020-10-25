using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private int currentSceneLevel;
    public static DeathMenu Instance { get; private set; }

    //basic singleton, so it can be access from other classes in the game.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //getting current scene build index and assign it to the value.
        currentSceneLevel = SceneManager.GetActiveScene().buildIndex;
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        //load scene with current scene index
        SceneManager.LoadScene(currentSceneLevel);
    }
}
