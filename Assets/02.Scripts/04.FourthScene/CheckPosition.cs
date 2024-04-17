using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DummyInfo
{
    public GameObject DummyModel;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftFoot;
    public GameObject RightFoot;
}

public class CheckPosition : MonoBehaviour
{
    int stageIndex = 1;

    public DummyInfo originalDummy = new DummyInfo();
    public DummyInfo DummyToCopy1 = new DummyInfo();
    public DummyInfo DummyToCopy2 = new DummyInfo();
    public DummyInfo DummyToCopy3 = new DummyInfo();


    public GameObject FirstToSecondBtn;
    public GameObject SecondToThirdBtn;
    public GameObject ThirdToFinishBtn;

    float DummyPositionDiff;

    float LeftHandDis;
    float RightHandDis;
    float LeftFootDis;
    float RightFootDis;

    float LF_DiffY;
    float RH_DiffY;
    float LH_DiffY;

    float diff = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        DummyPositionDiff = Vector3.Distance(originalDummy.DummyModel.transform.position, DummyToCopy1.DummyModel.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (stageIndex == 1) { CheckDummyPosition(ref DummyToCopy1); }
        else if (stageIndex == 2) { CheckDummyPosition(ref DummyToCopy2); }
        else if (stageIndex == 3) { CheckDummyPosition(ref DummyToCopy3); }
    }

    void CheckDummyPosition(ref DummyInfo info)
    {
        if (info.DummyModel.activeSelf == false)
            return;
        
        LeftHandDis = Vector3.Distance(originalDummy.LeftHand.transform.position, info.LeftHand.transform.position);
        RightHandDis = Vector3.Distance(originalDummy.RightHand.transform.position, info.RightHand.transform.position);
        LeftFootDis = Vector3.Distance(originalDummy.LeftFoot.transform.position, info.LeftFoot.transform.position);
        RightFootDis = Vector3.Distance(originalDummy.RightFoot.transform.position, DummyToCopy3.RightFoot.transform.position);

        if (DummyPositionDiff + diff <= LeftHandDis || LeftHandDis <= DummyPositionDiff - diff ||
            DummyPositionDiff + diff <= RightHandDis || RightHandDis <= DummyPositionDiff - diff ||
            DummyPositionDiff + diff <= LeftFootDis || LeftFootDis <= DummyPositionDiff - diff ||
            DummyPositionDiff + diff <= RightFootDis || RightFootDis <= DummyPositionDiff - diff)
        {
            return;
        }

        LF_DiffY = Mathf.Abs(info.LeftFoot.transform.position.y - originalDummy.LeftFoot.transform.position.y);
        RH_DiffY = Mathf.Abs(info.RightHand.transform.position.y - originalDummy.RightHand.transform.position.y);
        LH_DiffY = Mathf.Abs(info.LeftHand.transform.position.y - originalDummy.LeftHand.transform.position.y);

        if (stageIndex == 1)
        {
            info.DummyModel.SetActive(false);
            FirstToSecondBtn.SetActive(true);
            stageIndex++;
        }
        else if (stageIndex == 2 && CheckSecondDummyPosition())
        {
            info.DummyModel.SetActive(false);
            SecondToThirdBtn.SetActive(true);
            stageIndex++;
        }
        else if (stageIndex == 3 && CheckThirdDummyPosition())
        {
            info.DummyModel.SetActive(false);
            ThirdToFinishBtn.SetActive(true);
            stageIndex++;
        }
    }

    bool CheckSecondDummyPosition()
    {
        if (LF_DiffY <= diff)
            return true;
        return false;
    }

    bool CheckThirdDummyPosition()
    {
        if (LF_DiffY <= diff && RH_DiffY <= diff && LH_DiffY <= diff)
            return true;
        return false;
    }

}

//if (Input.GetKey(KeyCode.O))
//    Debug.Log("Second LeftHandDis : " + LeftHandDis);
//if (Input.GetKey(KeyCode.P))
//    Debug.Log("Second RightHandDis : " + RightHandDis);
//if (Input.GetKey(KeyCode.I))
//{
//    Debug.Log("SecondPosition LeftFootDis : " + LeftFootDis);
//}
//if (Input.GetKey(KeyCode.L))
//{
//    Debug.Log("Original Left Hand : " + originalDummy.LeftHand.transform.position.y);
//    Debug.Log("Original Right Hand : " + originalDummy.RightHand.transform.position.y);
//    Debug.Log("Original Left Foot : " + originalDummy.LeftFoot.transform.position.y);
//    Debug.Log("S3_LeftHandDiffY : " + S3_LeftHandDiffY);
//    Debug.Log("S3_RightHandDiffY : " + S3_RightHandDiffY);
//    Debug.Log("S3_LeftFootDiffY : " + S3_LeftFootDiffY);
//}