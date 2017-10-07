using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOrDisplayObject : StoryGameObject {
    public string nameOfObject;
    public bool isVisible;

    public override bool Execute()
    {
        var targetObject = transform.Find(nameOfObject);

        var element = targetObject.GetComponent<MeshRenderer>();
        if (element != null)
            element.enabled = isVisible;

        var elements = targetObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var e in elements)
            e.enabled = isVisible;

        var colliders = targetObject.GetComponentsInChildren<Collider>();
        foreach (var c in colliders)
            c.enabled = isVisible;

        var collider = targetObject.GetComponent<Collider>();
        if (collider != null)
            collider.enabled = isVisible;


        return false;
    }

}
