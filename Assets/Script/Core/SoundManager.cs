using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Truy cap bat ki dau thong qua SoundManager.instance
    public static SoundManager instance { get; private set; } // chi co the set duoc trong class nay
    private AudioSource source;
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound); //play audio clip only once
    }
}
