using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndDisplayDelayed : StoryGameObject {
    public string hideObject;
    public string displayObject;

    public float delaySeconds;
    private IEnumerator coroutine;
    private Transform hideTransform;
    private Transform displayTransform;

    public override bool Execute()
    {
        hideTransform = transform.Find(hideObject);
        displayTransform = transform.Find(displayObject);

        //coroutine = WaitAndDisplay(hideTransform, displayTransform, delaySeconds);
        //StartCoroutine(coroutine);
        Invoke("Action", delaySeconds);

        return false;
    }

    public void Action()
    {
        HideOrDisplayObject(hideTransform, false);
        HideOrDisplayObject(displayTransform, true);
    }

    private IEnumerator WaitAndDisplay(Transform hide, Transform display, float delay)
    {
        yield return new WaitForSeconds(delay);
        HideOrDisplayObject(hide, false);
        HideOrDisplayObject(display, true);
    }

    private void HideOrDisplayObject(Transform targetObject, bool isVisible)
    {
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
    }

}
