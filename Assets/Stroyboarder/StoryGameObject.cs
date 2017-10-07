using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Stroyboarder;
using UnityEngine;

public class StoryGameObject : MonoBehaviour, IStoryboardElement {
    public IStoryBoardController controller { get; set; }


    public bool givesFeedback { get; set; }
       

    virtual public bool Execute()
    {
        throw new NotImplementedException();
    }

    virtual public bool ShouldWaitLonger()
    {
        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
