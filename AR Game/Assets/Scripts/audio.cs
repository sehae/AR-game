using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void PauseAudio()
    {
        audioSource.Pause();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void MuteAudio(bool isMuted)
    {
        audioSource.mute = isMuted;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;  // Volume should be between 0.0 and 1.0
    }
}
