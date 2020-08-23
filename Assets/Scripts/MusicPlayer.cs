using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource musicPlayer;

    private void Awake()
    {
        musicPlayer = GetComponent<AudioSource>();
        DontDestroyOnLoad(musicPlayer);
    }
}
