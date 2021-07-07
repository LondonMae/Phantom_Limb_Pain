using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* knees will automatically bend
 * when in contact with the floor 
 */

public class VRFootIK : MonoBehaviour
{
    private Animator animator;
    public Vector3 footOffset;
    [Range(0,1)]
    public float rightFootPosWeight = 1;
    [Range(0, 1)]
    public float leftFootPosWeight = 1;
    [Range(0, 1)]
    public float rightFootRotWeight = 1;
    [Range(0, 1)]
    public float leftFootRotWeight = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // called automatically by animator 
    private void OnAnimatorIK(int layerIndex)
    {
        Vector3 rightFootPos = animator.GetIKPosition(AvatarIKGoal.RightFoot);
        RaycastHit hit;
        // have we hit the ground?
        bool hasHit = Physics.Raycast(rightFootPos + Vector3.up, Vector3.down, out hit);
        if (hasHit)
        {
            // set foot position to location of (contact + offset)
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootPosWeight);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + footOffset);

            // feet lay flat on the ground
            Quaternion rightFootRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootRotWeight);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation);
        }
        // otherwise, don't set position weight
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
        }

        // essentially same on the left
        Vector3 leftFootPos = animator.GetIKPosition(AvatarIKGoal.LeftFoot);
        // have we hit the ground?
        hasHit = Physics.Raycast(leftFootPos + Vector3.up, Vector3.down, out hit);
        if (hasHit)
        {
            // set foot position to location of (contact + offset)
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootPosWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + footOffset);

            // feet lay flat on the ground
            Quaternion leftFootRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootRotWeight);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRotation);
        }
        // otherwise, don't set position weight 
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
        }

    }
}
