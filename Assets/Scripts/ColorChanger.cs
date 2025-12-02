using System;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private readonly Dictionary<string, Color> _tagColorMap = new Dictionary<string, Color>
    {
        { "Red", Color.red },
        { "Green", Color.green },
        { "Yellow", Color.yellow },
        { "Grey", Color.grey }
    };

    private void OnCollisionEnter(Collision other)
    {
        if (_tagColorMap.TryGetValue(other.gameObject.tag, out var color)) 
            _meshRenderer.material.color = color;
    }
}