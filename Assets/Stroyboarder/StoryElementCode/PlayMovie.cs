using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayMovie : StoryGameObject {
    public bool waitForEnd = false;
    public string videoTarget;
    public VideoClip nameOfClip;
    public bool isLooping = false;

    public override bool Execute()
    {
        var videoTargetObj = transform.Find(videoTarget);

        var video = videoTargetObj.GetComponent<VideoPlayer>();

        video.clip = nameOfClip;
        video.isLooping = isLooping;
        video.Play();

        return waitForEnd;
    }
}
