using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelecterView : MonoBehaviour
{
    public Color _colorEnable, _colorDisabled;
    public float _intensity = 3f;
    public Transform _target;
    public float _lerp = 0.1f;
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, _lerp);
        transform.position = Vector3.Lerp(transform.position, _target.position, _lerp);
    }

    public void Enable(bool enabled)
    {
        Debug.Log("Setting color " + enabled);
        Color color = enabled ? _colorEnable : _colorDisabled;
        color *= _intensity;
        _material.SetColor("_EmissiveColor", color);
    }
}
