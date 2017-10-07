using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunColorController : MonoBehaviour {
    private MeshRenderer myGun;
    private MeshRenderer myWater;
    void Start () {
        myGun = transform.Find("Gun").GetComponentInChildren<MeshRenderer>();
        myWater = transform.Find("WaterEffect").GetComponentInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;

        var otherGunColorProvider = otherGameObject.GetComponent<GunColorProvider>();

        if (otherGunColorProvider == null)
            return;

        SetMaterialOnGameObject(myGun, 0, otherGunColorProvider.gunColor);
        SetMaterialOnGameObject(myWater, 0, otherGunColorProvider.gunColor);

    }

    private void SetMaterialOnGameObject(MeshRenderer targetMeshRenderer, int pos, Material newMaterial)
    {
        var mat = targetMeshRenderer.materials;
        mat[0] = newMaterial;
        targetMeshRenderer.materials = mat;
    }
}
