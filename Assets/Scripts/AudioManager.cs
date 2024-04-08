using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    int playingClipIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        playingClipIndex = Random.Range(0, clips.Length);
    }

    void PlayAudio()
    {
        source.clip = clips[playingClipIndex];
        source.Play();
    }

    void PlayInfiniteAudio()
    {
        source.clip = clips[playingClipIndex];
        source.Play();
        StartCoroutine(SwitchAudio());
    }

    IEnumerator SwitchAudio()
    {
        yield return new WaitForSeconds(source.clip.length);
        playingClipIndex = (playingClipIndex + 1) % clips.Length;
        PlayAudio();
    }
}
