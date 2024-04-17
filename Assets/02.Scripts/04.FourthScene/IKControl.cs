using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator; 
    public bool ikActive = false;
    [SerializeField] private Transform leftHandObj = null; 
    [SerializeField] private Transform rightHandObj = null;
    [SerializeField] private Transform leftFootObj = null; 
    [SerializeField] private Transform rightFootObj = null;
    //public Transform lookObj = null; //�ü��� ���� �� Object 

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
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.transform.position);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.transform.rotation);
                }
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.transform.position);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.transform.rotation);
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

            else // isActive == false
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);

                animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
            }
        }
    }
}

//if (lookObj != null) //�ü� ������Ʈ�� �ִٸ�
//{
//    animator.SetLookAtWeight(1); //�ü��� �־� IK �켱������ �������ش�. (0 ���� ~ 1 ����)
//    animator.SetLookAtPosition(lookObj.position);
//}

// else{animator.SetLookAtWeight(0);}