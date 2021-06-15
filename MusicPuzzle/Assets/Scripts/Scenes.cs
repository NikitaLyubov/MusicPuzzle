using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    private int previousScene;

    public void NextScene(int sceneIndex)
    {
        previousScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }
}
