using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject pauseButton;
    [SerializeField] private SoundData buttonSFX;


   
    public void Replay()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        Application.Quit();
    }

    public void MainMenu()
    {

        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Pause()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void StartGame()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        SceneManager.LoadScene("SampleScene");
    }
}
