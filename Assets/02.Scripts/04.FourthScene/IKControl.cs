using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator; // ������Ʈ�� Animator�� �޾ƿ�.
    public bool ikActive = false; //isActive�� üũ�Ǿ� �ִ��� ����
    [SerializeField] private Transform leftHandObj = null; //���� ���� ���� �� Object
    [SerializeField] private Transform rightHandObj = null; //������ ���� ���� �� Object
    [SerializeField] private Transform leftFootObj = null; //���� ���� ���� �� Object
    [SerializeField] private Transform rightFootObj = null; //������ ���� ���� �� Object
    public Transform lookObj = null; //�ü��� ���� �� Object 

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
                if (lookObj != null) //�ü� ������Ʈ�� �ִٸ�
                {
                    animator.SetLookAtWeight(1); //�ü��� �־� IK �켱������ �������ش�. (0 ���� ~ 1 ����)
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