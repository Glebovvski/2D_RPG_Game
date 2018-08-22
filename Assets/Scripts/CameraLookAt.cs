﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    public Vector3 cameraTarget = Vector3.zero;

    private void Update()
    {
        transform.LookAt(cameraTarget);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, cameraTarget);
    }
}
