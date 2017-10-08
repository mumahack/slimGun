using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StopVideo : StoryGameObject
{
    public string videoTarget;
    public override bool Execute()
    {
        var videoTargetObj = transform.Find(videoTarget);
        var video = videoTargetObj.GetComponent<VideoPlayer>();
        video.Stop();
        return false;
    }
}