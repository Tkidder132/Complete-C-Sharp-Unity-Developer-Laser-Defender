using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerController : MonoBehaviour
{
    public int brickCount = 0;

    public void CheckBrickCount()
    {
        if(brickCount <= 0)
        {
            LoadNextLevel();
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest()
    {
        //NOTE: Will not "work" in editor. 
        Application.Quit();
    }
}
