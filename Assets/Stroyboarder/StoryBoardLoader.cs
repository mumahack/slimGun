using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBoardLoader : MonoBehaviour {

    public List<StoryGameObject> myList;
    public bool startController = true;

	void Start () {
        var controller = GetComponent<StoryBoardController>();
        controller.elements = new List<IStoryboardElement>();

        foreach (var element in myList)
        {
            controller.elements.Add(element);
        }
        if (startController)
            controller.StartController();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
