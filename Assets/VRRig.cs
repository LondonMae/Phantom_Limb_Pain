using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// vars exposed in Inspector AND the value its set to will be saved in the scene file.
[System.Serializable]
public class VRMap
{
    public Transform vrTarget; // tracked VR devices (ie. headset)
    public Transform rigTarget; // location on avatar (ie. head)
    public Vector3 trackingPositionOffset; 
    public Vector3 trackingRotationOffset; 

    /* Map: 
     * sets rig transforms according to location of real player 
     * by tracking headset and controllers
    */
    public void Map()
    {
        //set rig to vr position displaced by offset
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        //set rig rotation to vr rotation displaced by rotation offset
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;
    public float turnSmoothness;
    public Transform headConstraint;
    public Vector3 headBodyOffset;

    void Start()
    {
        //headBody offset = difference in central avatar pos and headconstraint pos
        headBodyOffset = transform.position - headConstraint.position;
    }

    void FixedUpdate()
    {
        // avatar position = head position + head body offset 
        transform.position = headConstraint.position + headBodyOffset;
        // direction of avatar = interpolate currect direction and direction of head constraint
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized,Time.deltaTime * turnSmoothness);

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
