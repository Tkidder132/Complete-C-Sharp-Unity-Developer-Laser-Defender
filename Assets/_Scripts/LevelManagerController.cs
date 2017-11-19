using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        //NOTE: Will not "work" in editor. 
        Application.Quit();
    }
}
