using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {

    public GunColorController controllerLeft;
    public GunColorController controllerRight;
    public ShootOnTrigger shootLeft;
    public ShootOnTrigger shootRight;

    public GameObject redBucket;
    public GameObject blueBucket;
    public GameObject greenBucket;
    public GameObject orangeBucket;

    public GameObject targetRed;
    public GameObject targetBlue;
    public GameObject targetGreen;
    public GameObject targetOrange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            SetColor(controllerRight, redBucket);
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            ShootTarget(shootRight, targetRed);
        }
    }

    private void ShootTarget(ShootOnTrigger trigger, GameObject target)
    {
        trigger.HitObject(target);
    }

    private void SetColor(GunColorController controller, GameObject bucket)
    {
        controller.SetColor(bucket);
    }
}
