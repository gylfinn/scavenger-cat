using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Gylfi Scene Level 2");
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("Main Scene Level Selector");
    }
    public void QuitGame ()
    {
        Application.Quit();
    }

}
