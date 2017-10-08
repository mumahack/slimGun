using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : StoryGameObject {

    public string audioTarget;
    public override bool Execute()
    {
        var obj = transform.Find(audioTarget);
        var audio = obj.GetComponent<AudioSource>();
        audio.Stop();
        return false;
    }
}
