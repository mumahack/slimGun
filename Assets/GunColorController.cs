using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunColorController : MonoBehaviour {
    private MeshRenderer myGun;
    private MeshRenderer myWater;
    private string colorname;
    void Start () {
        colorname = "";
        myGun = transform.Find("Gun").GetComponentInChildren<MeshRenderer>();
        myWater = transform.Find("WaterEffect").GetComponentInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;

        SetColor(otherGameObject);

    }

    public void SetColor(GameObject otherGameObject)
    {
        var otherGunColorProvider = otherGameObject.GetComponent<GunColorProvider>();

        if (otherGunColorProvider == null)
            return;

        SetMaterialOnGameObject(myGun, 0, otherGunColorProvider.gunColor);
        SetMaterialOnGameObject(myWater, 0, otherGunColorProvider.gunColor);
        colorname = otherGunColorProvider.gunColor.name;
    }

    public string getColorElementName()
    {
        return colorname;
    }

    private void SetMaterialOnGameObject(MeshRenderer targetMeshRenderer, int pos, Material newMaterial)
    {
        var mat = targetMeshRenderer.materials;
        mat[0] = newMaterial;
        targetMeshRenderer.materials = mat;
    }
}
