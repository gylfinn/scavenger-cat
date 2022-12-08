using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    private int currentLevel;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenScene1 () 
    {
        SceneManager.LoadScene(1);
    }
    public void OpenScene2 () 
    {
        SceneManager.LoadScene(2);
    }
    public void OpenScene3 () 
    {
        SceneManager.LoadScene(3);
    }
    public void OpenScene4 () 
    {
        SceneManager.LoadScene(4);
    }
    public void OpenScene5 () 
    {
        SceneManager.LoadScene(5);
    }
    public void OpenScene6 () 
    {
        //Currently only have 5 levels
        SceneManager.LoadScene(1);
    }
    public void OpenLevelSelectSceme () 
    {
        SceneManager.LoadScene("Main Scene Level Selector");
    }
    public void OpenMainMenuScreen () 
    {
        SceneManager.LoadScene(0);
    }
    public void PlayCurrentLevel()
    {
        GameManager.instance.LoadCurrentLevel();
    }
    public void PlayGame () 
    {
        SceneManager.LoadScene("Main Scene Level 1");
    }
    

}
