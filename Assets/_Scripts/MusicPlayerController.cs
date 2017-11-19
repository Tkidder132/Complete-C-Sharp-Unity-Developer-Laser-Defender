using UnityEngine;

public class MusicPlayerController : MonoBehaviour
{
    static MusicPlayerController instance = null;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}