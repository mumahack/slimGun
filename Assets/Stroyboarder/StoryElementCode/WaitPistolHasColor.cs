using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitPistolHasColor : StoryGameObject {
    public string colorname;
    public GunColorController[] colorControllers;

    public override bool Execute()
    {
        colorControllers= FindObjectsOfType<GunColorController>();

        return !hasGunColor();
    }

    public override bool ShouldWaitLonger()
    {
        return !hasGunColor();
    }

    private bool hasGunColor()
    {
        foreach(var gun in colorControllers)
        {
            if (gun.getColorElementName().Contains(colorname))
            {
                return true;
            }
        }
        return false;
    }
}
