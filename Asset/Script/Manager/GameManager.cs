using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    public static bool gameOver;
    public static bool levelCompleted;
    public  bool isGameStarted = false;
    internal static bool mute= false;

    public bool IsDead { set; get; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
         gameOver = levelCompleted = false;
        
    }

    public void OnRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void OnMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void OnPause()
    {
        Time.timeScale = 0;
    }

    public void OnResume()
    {
        Time.timeScale = 1;
    }

    public void OnExit()
    {
        Application.Quit();
    }
}