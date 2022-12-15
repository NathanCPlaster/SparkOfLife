using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinHandler : MonoBehaviour
{
    public GameObject WinScreen;

    private void OnEnable()
    {
        BossAI.bossDeath += EnableWinMenu;
    }

    private void OnDisable()
    {
        BossAI.bossDeath -= EnableWinMenu;
        Time.timeScale = 1;
    }

    public void EnableWinMenu()
    {
        WinScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
