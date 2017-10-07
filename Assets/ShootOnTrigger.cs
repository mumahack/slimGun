using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ShootOnTrigger : MonoBehaviour {
    private VRTK_ControllerEvents myController;
    private GameObject myWater;
    private GameObject myGunColor;
    private GameObject myGun;

    // Use this for initialization
    void Start () {
        myWater = transform.Find("ColorGun/WaterEffect").gameObject;
        myGunColor = transform.Find("ColorGun").gameObject;
        myGun = transform.Find("ColorGun/Gun").gameObject;
        myController = this.GetComponent<VRTK_ControllerEvents>();

        myController.TriggerClicked += TriggerClicked;
        myController.TriggerReleased += TriggerReleased;

        //UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0);
    }

    private void Update()
    {
        Vector3 forward = myGunColor.transform.TransformDirection(Vector3.left) * 10;
        Vector3 startpoint = myGunColor.transform.position;
        startpoint.y += 0.1f;
        Debug.DrawRay(startpoint, forward, Color.blue);
    }

    private void TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        myWater.SetActive(false);
    }

    private void TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        Shoot();
    }

    private void Shoot()
    {
        myWater.SetActive(true);

        Vector3 forward = myGunColor.transform.TransformDirection(Vector3.left) * 10;
        Vector3 startpoint = myGunColor.transform.position;
        startpoint.y += 0.1f;

        var layermask = 1 << LayerMask.NameToLayer("Target");
        var uiLayermask = 1 << LayerMask.NameToLayer("UI");

        var debughits = Physics.RaycastAll(startpoint, forward, 100.0F);

        RaycastHit raycastHitinfo;

        if (Physics.Raycast(origin: startpoint, direction: forward, layerMask: layermask, hitInfo: out raycastHitinfo, maxDistance: 199))
        {
            var targetGameObject = raycastHitinfo.collider.gameObject;
            var targetMeshRenderer = targetGameObject.transform.GetComponent<MeshRenderer>();
            var targetMaterial = targetMeshRenderer.materials[0];

            var gunMeshRenderer = myGun.transform.GetComponent<MeshRenderer>();
            var gunMeterial = gunMeshRenderer.materials[0];

            if (targetMaterial.name == gunMeterial.name)
            {
                HitObject(targetGameObject);
            }
        } else if (Physics.Raycast(origin: startpoint, direction: forward, layerMask: uiLayermask, hitInfo: out raycastHitinfo, maxDistance: 199))
        {
            var targetGameObject = raycastHitinfo.collider.gameObject;
            var buttonScript = targetGameObject.GetComponent<Button>();

            if (buttonScript != null)
            {
                buttonScript.onClick.Invoke();
            }

        }


    }

    public void HitObject(GameObject targetGameObject)
    {
        // targetGameObject.SetActive(false);
        ChangeVisbility(targetGameObject, false);
    }

    private void ChangeVisbility(GameObject targetObject, bool isVisible)
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
