using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource audioSource;

    public AudioClip menuClip;
    public AudioClip backgroundClip;
    private void Awake()
    {
        // Singleton pattern — ensures only one MusicManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // destroy duplicate
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // keep it alive across scenes

        audioSource = GetComponent<AudioSource>();
    }
    public void SwitchMusic(AudioClip newClip, float fadeTime = 1f)
    {
        StartCoroutine(FadeMusic(newClip, fadeTime));
    }

    private IEnumerator FadeMusic(AudioClip newClip, float fadeTime)
    {
        float startVolume = audioSource.volume;

        // Fade out
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeTime);
            yield return null;
        }

        audioSource.clip = newClip;
        audioSource.Play();

        // Fade in
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, startVolume, t / fadeTime);
            yield return null;
        }
    }
}
