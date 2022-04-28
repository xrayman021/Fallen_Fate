using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadLevel()
    {
        // get current build index, from the current scene
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        // load this scene (basically loads itself)
        SceneManager.LoadScene(currentBuildIndex);
    }
}
