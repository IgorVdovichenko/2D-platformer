
using UnityEngine;

public struct PauseAudioSettings
{
    public AudioSource AudioSource { get; private set; }
    public MusicManager Music { get; private set; }
    public AudioClip Sound { get; private set; }

    public PauseAudioSettings(AudioSource audioSource, MusicManager music, AudioClip sound)
    {
        this.AudioSource = audioSource;
        this.Music = music;
        this.Sound = sound;
    }
}
