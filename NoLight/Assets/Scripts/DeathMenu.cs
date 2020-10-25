using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private int currentSceneLevel;
    public static DeathMenu Instance { get; private set; }
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
        currentSceneLevel = SceneManager.GetActiveScene().buildIndex;
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(currentSceneLevel);
    }
}
