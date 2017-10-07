using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTargetHit : StoryGameObject
{
    public string targetPath;
    public int numbers;
    private Transform targetObject;

    public override bool Execute()
    {
        targetObject = transform.Find(targetPath);

        if (!targetObject)
            return false;

        return !targetVisible();
    }

    public override bool ShouldWaitLonger()
    {
        return !targetVisible();
    }

    private bool targetVisible()
    {
        var renderer = targetObject.GetComponent<MeshRenderer>();

        if (renderer == null)
        {
            renderer = targetObject.GetComponentsInChildren<MeshRenderer>()[0];
        }

        if (renderer.enabled)
            return false;

        return true;
    }
}
