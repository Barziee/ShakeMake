using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundTypes { FruitTap, WinSound, LoseSound, GameWin, Pouring, OrderSpawn, ClockTick, Blender, MusicLoop }

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;

    public AudioClip[] audioClips;

    private AudioSource audioSource;


    public Dictionary<SoundTypes, AudioClip> soundTypeToClip;

    private void Awake()
    {
        audioManager = this;
        audioSource = GetComponent<AudioSource>();
        soundTypeToClip = new Dictionary<SoundTypes, AudioClip>();
        //soundTypeToClip.Add(SoundTypes.FruitTap, audioClips[0]);
        for (int i = 0; i < audioClips.Length; i++)
        {
            soundTypeToClip.Add((SoundTypes)i, audioClips[i]);
        }

    }


    public void PlaySound(SoundTypes soundType)
    {
        audioSource.clip = soundTypeToClip[soundType];
        audioSource.Play();
    }

    public void StopSound(SoundTypes soundType)
    {
        audioSource.clip = soundTypeToClip[soundType];
        audioSource.Stop();
    }











}
