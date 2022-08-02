using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;

    public void SwitchScene(int indexBuild)
    {
        StartCoroutine(LoadGameScene(indexBuild));
    }

    private IEnumerator LoadGameScene(int index)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
