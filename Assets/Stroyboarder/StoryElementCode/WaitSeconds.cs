using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSeconds : StoryGameObject
{
    public float delaySeconds;
    private bool timeIsOver;

    public override bool Execute()
    {
        timeIsOver = false;
        Invoke("Action", delaySeconds);

        return true;
    }

    public override bool ShouldWaitLonger()
    {
        return !timeIsOver;
    }


    private void Action()
    {
        timeIsOver = true;
    }


}

