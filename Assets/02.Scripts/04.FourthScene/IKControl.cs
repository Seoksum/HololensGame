using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator; // 오브젝트의 Animator을 받아옴.
    public bool ikActive = false; //isActive가 체크되어 있는지 여부
    [SerializeField] private Transform leftHandObj = null; //왼쪽 손이 따라 갈 Object
    [SerializeField] private Transform rightHandObj = null; //오른쪽 손이 따라 갈 Object
    [SerializeField] private Transform leftFootObj = null; //왼쪽 발이 따라 갈 Object
    [SerializeField] private Transform rightFootObj = null; //오른쪽 발이 따라 갈 Object
    public Transform lookObj = null; //시선을 따라 갈 Object 

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnAnimatorIK()
    {

        if (animator)
        {
            if (ikActive)
            {
                if (lookObj != null) //시선 오브젝트가 있다면
                {
                    animator.SetLookAtWeight(1); //시선에 있어 IK 우선순위를 결정해준다. (0 낮음 ~ 1 높음)
                    animator.SetLookAtPosition(lookObj.position);
                }
                // Set the right hand target position and rotation, if one has been assigned
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.transform.position);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.transform.rotation);
                    //transform.position = leftHandObj.transform.position;
                }
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.transform.position);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.transform.rotation);
                    //transform.position = rightHandObj.transform.position;
                }
                if (leftFootObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootObj.transform.position);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootObj.transform.rotation);
                    //transform.position = rightHandObj.transform.position;
                }
                if (rightFootObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootObj.transform.position);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootObj.transform.rotation);
                    //transform.position = rightHandObj.transform.position;
                }
            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);

                animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
}