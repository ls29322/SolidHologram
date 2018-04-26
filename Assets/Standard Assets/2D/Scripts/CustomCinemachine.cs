﻿using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCinemachine : MonoBehaviour
{
    public CinemachineVirtualCamera mainVirtualCamera;

    private Transform playerTransform;    

    void Update()
    {
        if (playerTransform != null)
        {
            //transform.position = playerTransform.position + new Vector3(horizontalDisplacement, verticalDisplacement, depth);
            mainVirtualCamera.Follow = playerTransform;
        }
    }

    public void setTarget(Transform target)
    {
        playerTransform = target;
    }
}
