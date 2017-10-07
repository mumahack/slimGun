using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOrDisplayObject : StoryGameObject {
    public string nameOfObject;
    public bool isVisible;

    public override bool Exectue()
    {
        var targetObject = transform.Find(nameOfObject);
        targetObject.gameObject.SetActive(isVisible);

        return false;
    }

}
