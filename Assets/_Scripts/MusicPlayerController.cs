using UnityEngine;

public class MusicPlayerController : MonoBehaviour
{
    static MusicPlayerController instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    private void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate Music Player: Self Destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer: Loaded level " + level);
        music.Stop();

        switch(level)
        {
            case 0:
                music.clip = startClip;
                break;
            case 1:
                music.clip = gameClip;
                break;
            case 2:
            case 3:
                music.clip = endClip;
                break;
            default:
                music.clip = gameClip;
                break;
        }

        music.loop = true;
        music.Play();
    }
}