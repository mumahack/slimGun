using Assets.Stroyboarder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryBoardController : MonoBehaviour, IStoryBoardController {
    public List<IStoryboardElement> elements { get; set; }
    private bool isWaitingForElement = false;
    private bool controllerRuns = false;
    public int currentPosition = 0;

    // Use this for initialization
    void Start () {      
        
    }
	
	void Update () {
        do
        {
            if (elements != null && controllerRuns)
            {
                if (isWaitingForElement)
                {
                    isWaitingForElement = elements[currentPosition].ShouldWaitLonger();
                    if (!isWaitingForElement)
                        currentPosition++;
                }
                else
                    ExecuteNextStoryElement();
            }
        } while (elements != null && controllerRuns && !isWaitingForElement);
		
	}

    private void ExecuteNextStoryElement()
    {
        bool shouldIwait = false;

        try
        {
            shouldIwait = elements[currentPosition].Exectue();
        } catch (Exception e)
        {

        }
        
        if (shouldIwait == true)
        {
            isWaitingForElement=true;
        } else
            currentPosition++;

        if (currentPosition > elements.Count)
        {
            StopController();
            currentPosition = 0;
        }

    }

    public void StartController()
    {
        controllerRuns = true;
    }

    public void StopController()
    {
        controllerRuns = false;
    }
}
