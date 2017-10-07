using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour {
    private AudioSource audio;

    public AudioClip[] clips;
    
    private int currentSong = 0;
    private bool playerStarted;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        playerStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerStarted == true && audio.isPlaying == false)
        {
            PlayNextSong();
        }
		
	}

    public void PlayMusic()
    {
        playerStarted = true;
        audio.Stop();
        audio.PlayOneShot(clips[currentSong]);
    }

    public void PauseSong()
    {
        playerStarted = false;
        audio.Stop();
    }

    public void PlayNextSong()
    {
        currentSong++;
        currentSong %= clips.Length;
        PlayMusic();
    }

    public void VolumeUp()
    {
        audio.volume = Mathf.Min(1.0f, audio.volume + 0.1f);
    }

    public void VolumeDown()
    {
        audio.volume = Mathf.Max(0.1f, audio.volume - 0.1f);
    }

}
