using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        LifeSystem.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        LifeSystem.OnPlayerDeath -= EnableGameOverMenu;
        Time.timeScale = 1;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
