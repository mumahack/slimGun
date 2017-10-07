using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : StoryGameObject {
    public AudioClip myAudioClip;
    public string nameOfAudioSource = "";
    public bool waitForEnd = false;
    AudioSource audiosource;

    public override bool Exectue()
    {
        

        var audiosourceObj = transform.Find(nameOfAudioSource);
        if (audiosourceObj == null)
            audiosource = FindObjectOfType<AudioSource>();
        
         audiosource = audiosourceObj.GetComponent<AudioSource>();

        audiosource.PlayOneShot(myAudioClip);
        return waitForEnd;
    }

    public override bool ShouldWaitLonger()
    {
        
        if (audiosource.isPlaying)
            return true;

        return false;
    }
}
