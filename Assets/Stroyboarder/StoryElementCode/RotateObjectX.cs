using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectX : StoryGameObject {

    public string targetObject;
    public AnimationClip animClip;

    public override bool Execute()
    {
        var obj = transform.Find(targetObject);

        var anim = obj.gameObject.AddComponent<Animation>();

        animClip.wrapMode = WrapMode.Loop;

        anim.AddClip(animClip, animClip.name);
        anim.clip = animClip;
        anim.Play();
        return false;
    }
}
