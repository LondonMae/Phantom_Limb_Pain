using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * use headset movement to change 
 * parameters for animator
 */

public class VRAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Vector3 previousPos;
    private VRRig vrRig;
    public float speedThreshold = 0.15f;
    [Range(0, 1)]
    public float smoothing = 1;
    public float weight = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VRRig>();

        previousPos = vrRig.head.vrTarget.position;
        animator.SetLayerWeight(1, weight);
    }

    // Update is called once per frame
    void Update()
    {
        //get x and z velocity of headset
        Vector3 headsetSpeed = (vrRig.head.vrTarget.position - previousPos) / Time.deltaTime;
        headsetSpeed.y = 0;
        // get speed according to direction of player (from world space to local space) 
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        previousPos = vrRig.head.vrTarget.position;

        float previousDirectionX = animator.GetFloat("DirectionX");
        float previousDirectionY = animator.GetFloat("DirectionY");

        // if speed exceeds threshold, make player walk
        animator.SetBool("isMoving", headsetLocalSpeed.magnitude > speedThreshold);
        // set speed, not going less than -1 or more than 1
        animator.SetFloat("DirectionX", Mathf.Lerp(previousDirectionX, Mathf.Clamp(headsetLocalSpeed.x, -1, 1), smoothing));
        animator.SetFloat("DirectionY", Mathf.Lerp(previousDirectionY, Mathf.Clamp(headsetLocalSpeed.z, -1, 1), smoothing));
    }
}
