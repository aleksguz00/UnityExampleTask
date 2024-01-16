using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    // [SerializeField] private Transform _camera;

    private string Horizontal = nameof(Horizontal);
    private string Vertical = nameof(Vertical);
    private string MouseX = "Mouse X";
    private string MouseY = "Mouse Y";

    private void Update()
    {
        MoveForward();
        MoveRight();
        Rotate();
    }

    private void MoveForward()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = direction * _speed * Time.deltaTime;
        transform.Translate(distance * Vector3.forward);
    }

    private void MoveRight()
    {
        float direction = Input.GetAxis(Horizontal);
        float distance = direction * _speed * Time.deltaTime;
        transform.Translate(distance * Vector3.right);
    }

    private void Rotate()
    {
        // _camera.Rotate(-Input.GetAxis(MouseY) * _rotationSpeed * Time.deltaTime * _camera.right);
        transform.Rotate(Input.GetAxis(MouseX) * _rotationSpeed * Time.deltaTime * transform.up);
    }
}
