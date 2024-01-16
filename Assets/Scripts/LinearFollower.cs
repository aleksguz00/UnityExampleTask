using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearFollower : MonoBehaviour
{
    [SerializeField] private GameObject _checkpointGroup;
    [SerializeField] private float _speed;

    private Transform[] _checkpoints;
    private int currentCheckpoint = 0;
    private int nextCheckpoint = 1;

    private void Start()
    {
        _checkpoints = _checkpointGroup.GetComponentsInChildren<Transform>();

        Array.Copy(_checkpoints, 1, _checkpoints, 0, _checkpoints.Length - 1);
        Array.Resize(ref _checkpoints, _checkpoints.Length - 1);

        Debug.Log($"Length: {_checkpoints.Length}");
        Debug.Log($"First elem: {_checkpoints[0]}");
        /*
        if (_checkpoints.Length == 1)
        {
            nextCheckpoint = 0;
        }
        */
        transform.position = Vector3.MoveTowards(transform.position, _checkpoints[currentCheckpoint].position, _speed * Time.deltaTime);
    }

    private void Update()
    {
        if (currentCheckpoint != _checkpoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                _checkpoints[currentCheckpoint].position,
                _speed * Time.deltaTime
                );
            if (transform.position == _checkpoints[currentCheckpoint].position)
            {
                currentCheckpoint++;
                nextCheckpoint++;
            }

            if (nextCheckpoint <= _checkpoints.Length - 1)
            {
                transform.LookAt(_checkpoints[nextCheckpoint]); // Error, when reaches
            }            
        }
        else
        {
            // transform.position = _checkpoints[_checkpoints.Length - 1].position;
        }
    }
}
