using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public void PauseGame()
    {
        Debug.Log("Pause");
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume");
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void ExitToMainMenu()
    {
        Debug.Log("ExitToMainMenu");
        SceneManager.LoadScene("MenuScene");
    }
}
