using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerBehaviour player;

    public int currentLevel => SceneManager.GetActiveScene().buildIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeScene(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }

    public void SetLevelWaves()
    {

    }
}
