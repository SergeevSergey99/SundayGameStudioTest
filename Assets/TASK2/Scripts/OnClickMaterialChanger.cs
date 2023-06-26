using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]
public class OnClickMaterialChanger : MonoBehaviour
{
    [SerializeField] private List<Material> materials;

    private MeshRenderer _meshRenderer;
    private Collider _collider;
    private int _currentMaterialIndex = 0;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        
        SetMaterial(0);
    }

    void SetMaterial(int index)
    {
        if (index < 0 || index >= materials.Count) return;
        _currentMaterialIndex = index;
        _meshRenderer.material = materials[_currentMaterialIndex];
    }
    void SetNextMaterial()
    {
        SetMaterial((_currentMaterialIndex + 1) % materials.Count);
    }

    private void OnMouseDown()
    {
        SetNextMaterial();
    }
}
