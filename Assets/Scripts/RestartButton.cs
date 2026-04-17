using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    bool setMenu = true;
    [SerializeField] GameObject loseMenu;
    [SerializeField] Animator cameraAnim;
    static bool restartGame = false;
    void Start()
    {
        if (restartGame)
        {
            // если это рестарт
            Time.timeScale = 1f;
            Menu.SetActive(false);
            restartGame = false;

        }
        else
        {
            // если это обычный запуск игры
            Time.timeScale = 0f;
            Menu.SetActive(true);
        }

    }


    void Update()
    {

    }
    public void RestartGame()
    {
        restartGame = true;
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void MenuExit()
    {
        Time.timeScale = 0f;
        Menu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void StartGame()
    {
        setMenu = false;
        loseMenu.SetActive(false);
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }
}
