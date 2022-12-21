using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public GameObject gameOverPanel;

    public static GameManager Instance;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(this);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Debug.Log("Over");
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
            
    }
}
