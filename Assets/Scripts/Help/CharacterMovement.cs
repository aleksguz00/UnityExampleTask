using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;
    [SerializeField]private GameObject checkpointsCollection;

    private Transform[] checkpoints;

    private int currentCheckpointIndex = 0;
    
    private void MoveToCheckpoint(int index)
    {
        if (index < 0 || index >= checkpoints.Length)
        {
            Debug.LogError("Incorrect checkpoint index");
            return;
        }

        transform.position = checkpoints[index].position;
    }

    private void MoveToNextCheckpoint()
    {
        if (currentCheckpointIndex + 1 < checkpoints.Length)
        {
            currentCheckpointIndex++;
            MoveToCheckpoint(currentCheckpointIndex);
        }
        else
        {
            Debug.Log("The last checkpoint is reached");
        }
    }

    private void Start()
    {
        checkpoints = checkpointsCollection.GetComponentsInChildren<Transform>();
        MoveToCheckpoint(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToNextCheckpoint();
        }
    }
}
