using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private GameObject _observer;
    [SerializeField] private Transform _target;

    private Transform[] _cameras;
    private Quaternion[] _startRotations;

    private void Start()
    {
        _cameras = _observer.GetComponentsInChildren<Transform>();
        Array.Copy(_cameras, 1, _cameras, 0, _cameras.Length - 1);
        Array.Resize(ref _cameras, _cameras.Length - 1);

        _startRotations = new Quaternion[_cameras.Length];

        for (int i = 0; i < _cameras.Length; i++)
        {
            _startRotations[i] = _cameras[i].rotation;
        }
        Debug.Log(_startRotations.Length);
    }

    private void Update()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {          
            float distance = Vector3.Distance(_cameras[i].position, _target.position);
            if (distance < 11f)
            {
                _cameras[i].LookAt(_target);
            }         
            else
            {                
                _cameras[i].rotation = _startRotations[i];
            }
        }
    }
}
