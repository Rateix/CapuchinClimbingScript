using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;
using System;

public class CapuchinClimbtest : MonoBehaviour
{
    [Header("Capuchin Climbing By Rateix! This isnt yours.")]
    public Rigidbody leftController;
    public Rigidbody rightController;

    public Rigidbody rb;

    public float LeftDistance;
    public float RightDistance;
    public bool holdingleft;
    public bool holdingright;

    public float proximityDistance = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Collider[] leftColliders = Physics.OverlapSphere(leftController.position, proximityDistance);
        Collider[] rightColliders = Physics.OverlapSphere(rightController.position, proximityDistance);
        
        holdingleft = EasyInputs.GetGripButtonDown(EasyHand.LeftHand) && leftColliders.Length > 0;
        holdingright = EasyInputs.GetGripButtonDown(EasyHand.RightHand) && rightColliders.Length > 0;

        HandleClimbing(holdingleft, leftController);
        HandleClimbing(holdingright, rightController);
    }

private void HandleClimbing(bool isHolding, Rigidbody controller)
{
    FixedJoint fixedJoint = controller.GetComponent<FixedJoint>();

   
    Collider[] nearbyColliders = Physics.OverlapSphere(controller.position, proximityDistance);
    
    bool isNearTargetObject = Array.Exists(nearbyColliders, collider => collider.attachedRigidbody == rb);

    
    if (isHolding && isNearTargetObject)
    {
        if (fixedJoint == null)
        {
            fixedJoint = controller.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = rb;
        }
    }
  
    else if (!isHolding)
    {
        if (fixedJoint != null)
        {
            Destroy(fixedJoint);
        }
    }
}





}
// MIT License

// Copyright (c) 2023 Rateix

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
