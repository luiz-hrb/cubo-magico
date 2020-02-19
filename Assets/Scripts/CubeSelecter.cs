using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Left, Right }

public class CubeSelecter : MonoBehaviour
{
    public Transform _parentBlocks;
    public CubeSelecterView _selecterView;
    public List<Block> _blocks;
    private int _height;
    private Vector3 _rotation;
    private bool _isSelected;

    private void Update()
    {
        UpdatePosition();
        UpdateRotation();
        UpdateChildren();
    }

    private void OnTriggerEnter(Collider other)
    {
        Block block = other.GetComponent<Block>();
        if (block != null)
            AddBlock(block);
    }

    private void OnTriggerExit(Collider other)
    {
        Block block = other.GetComponent<Block>();
        if (block != null)
            RemoveBlock(block);
    }

    private void AddBlock(Block block)
    {
        _blocks.Add(block);
    }

    private void RemoveBlock(Block block)
    {
        _blocks.Remove(block);
    }

    private void MoveHeight(int move)
    {
        if (_isSelected)
            return;
        _height = Mathf.Clamp(_height + move, -1, 1);

        Vector3 position = transform.localPosition;
        position.y = _height;
        transform.localPosition = position;
    }

    private void Rotate(float degrees)
    {
        _rotation.y += degrees;
        transform.localRotation = Quaternion.Euler(_rotation);
    }

    private void UpdatePosition()
    {
        if (Input.GetKeyDown(KeyCode.W))
            MoveHeight(1);
        else if (Input.GetKeyDown(KeyCode.S))
            MoveHeight(-1);
    }

    private void UpdateRotation()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Rotate(-90);
        else if (Input.GetKeyDown(KeyCode.D))
            Rotate(90);
    }

    private void UpdateChildren()
    {
        if (Input.GetKeyDown(KeyCode.I))
            InsertChildren();
        else if (Input.GetKeyDown(KeyCode.O))
            ClearChildren();
    }

    private void InsertChildren()
    {
        _isSelected = true;
        _selecterView.Enable(true);
        foreach (var child in _blocks)
            child.transform.parent = transform;
    }

    private void ClearChildren()
    {
        _isSelected = false;
        _selecterView.Enable(false);
        foreach (var child in _blocks)
            child.transform.parent = _parentBlocks;
    }
}

