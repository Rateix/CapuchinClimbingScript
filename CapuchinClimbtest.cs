using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class CapuchinClimbtest : MonoBehaviour
{
    [Header("Capuchin Climbing By Rateix! This isnt yours. ")]
    public Rigidbody leftController;
    public Rigidbody rightController;

   public Rigidbody rb;

    public float LeftDistance;
    public float RightDistance;
   public bool holdingleft;
    public bool holdingright;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.GetComponent<Transform>();
        leftController.GetComponent<Transform>();
        rightController.GetComponent<Transform>();
    }

    void Update()
    {
        LeftDistance = Vector3.Distance(rb.position, leftController.position);
        RightDistance = Vector3.Distance(rb.position, rightController.position);
        if (EasyInputs.GetGripButtonDown(EasyHand.LeftHand))
        {
            holdingleft = true; 
        }
        else
        {
            holdingleft = false;
        }
        if (EasyInputs.GetGripButtonDown(EasyHand.RightHand))
        {
            holdingright = true;
        }
        else
        {
            holdingright = false;
        }

if (LeftDistance < 0.5f && holdingleft)
{
    if (leftController.GetComponent<FixedJoint>() == null)
    {
        FixedJoint fixedJoint = leftController.gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = rb;
    }
}
else
{
    FixedJoint fixedJoint = leftController.GetComponent<FixedJoint>();
    if (fixedJoint != null)
    {
        Destroy(fixedJoint);
    }
}

if (RightDistance < 0.5f && holdingright)
{
    if (rightController.GetComponent<FixedJoint>() == null)
    {
        FixedJoint fixedJoint = rightController.gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = rb;
}
}
else
{
    FixedJoint fixedJoint = rightController.GetComponent<FixedJoint>();
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