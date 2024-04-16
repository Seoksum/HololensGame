using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Original
{
    public GameObject OriginalModel;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftFoot;
    public GameObject RightFoot;
}
[System.Serializable]
public struct FirstCopied
{
    public GameObject FirstModel;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftFoot;
    public GameObject RightFoot;
}
[System.Serializable]
public struct SecondCopied
{
    public GameObject SecondModel;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftFoot;
    public GameObject RightFoot;
}
[System.Serializable]
public struct ThirdCopied
{
    public GameObject ThirdModel;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftFoot;
    public GameObject RightFoot;
}

public class CheckPosition : MonoBehaviour
{
    public Original original = new Original();
    public FirstCopied copied = new FirstCopied();
    public SecondCopied copied2 = new SecondCopied();
    public ThirdCopied copied3 = new ThirdCopied();


    public GameObject FirstToSecondBtn;
    public GameObject SecondToThirdBtn;
    public GameObject ThirdToFinishBtn;

    float OriginalToFirstDis;
    float OriginalToSecond;
    double OriginalToThird;

    float LeftHandDis;
    float RightHandDis;
    float LeftFootDis;
    float RightFootDis;

    float secondY;
    float ThirdY;

    // Start is called before the first frame update
    void Start()
    {
        OriginalToFirstDis = Vector3.Distance(original.OriginalModel.transform.position, copied.FirstModel.transform.position);
        OriginalToSecond = Vector3.Distance(original.OriginalModel.transform.position, copied2.SecondModel.transform.position);
        OriginalToThird = Vector3.Distance(original.OriginalModel.transform.position, copied3.ThirdModel.transform.position);

        Debug.Log("OriginalToFirstDis : "+ OriginalToFirstDis);
        Debug.Log("OriginalToSecond : " + OriginalToSecond);
        Debug.Log("OriginalToThird : " + OriginalToThird);


        secondY = copied2.LeftFoot.transform.localPosition.y;
        ThirdY = copied3.RightHand.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        FirstPosition();
        SecondPosition();
        ThirdPosition();
    }
    void FirstPosition()
    {

        if (copied.FirstModel.activeSelf == true)
        {
            LeftHandDis = Vector3.Distance(original.LeftHand.transform.position, copied.LeftHand.transform.position);
            RightHandDis = Vector3.Distance(original.RightHand.transform.position, copied.RightHand.transform.position);
            LeftFootDis = Vector3.Distance(original.LeftFoot.transform.position, copied.LeftFoot.transform.position);
            RightFootDis = Vector3.Distance(original.RightFoot.transform.position, copied.RightFoot.transform.position);

            if (LeftHandDis >= OriginalToFirstDis - 1.0f && LeftHandDis < OriginalToFirstDis
                && RightHandDis >= OriginalToFirstDis - 1.0f && RightHandDis < OriginalToFirstDis)
            {
                copied.FirstModel.SetActive(false);
                FirstToSecondBtn.SetActive(true);
            }
        }
    }

    void SecondPosition()
    {
        LeftHandDis = Vector3.Distance(original.LeftHand.transform.position, copied2.LeftHand.transform.position);
        RightHandDis = Vector3.Distance(original.RightHand.transform.position, copied2.RightHand.transform.position);
        LeftFootDis = Vector3.Distance(original.LeftFoot.transform.position, copied2.LeftFoot.transform.position);
        RightFootDis = Vector3.Distance(original.RightFoot.transform.position, copied2.RightFoot.transform.position);
        
        if (copied2.SecondModel.activeSelf == true)
        {

            if (LeftHandDis > OriginalToFirstDis - 0.2f && LeftHandDis < OriginalToFirstDis + 0.15f &&
               RightHandDis > OriginalToFirstDis - 0.2f && RightHandDis < OriginalToFirstDis + 0.15f &&
               LeftFootDis > OriginalToFirstDis - 0.2f&& original.LeftFoot.transform.position.y >= secondY-0.2f)// + 0.1f && original.LeftFoot.transform.position.y>secondY-0.1f)
            {
                copied2.SecondModel.SetActive(false);
                SecondToThirdBtn.SetActive(true);

            }

        }
        if (Input.GetKey(KeyCode.O))
            Debug.Log("Second LeftHandDis : " + LeftHandDis);
        if (Input.GetKey(KeyCode.P))
            Debug.Log("Second RightHandDis : " + RightHandDis);
        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("SecondPosition LeftFootDis : " + LeftFootDis);          
        }
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("OriginalToFirstDis : " + OriginalToFirstDis);
            Debug.Log("OriginalToSecond : " + OriginalToSecond);
            Debug.Log("OriginalToThird : " + OriginalToThird);
        }
    }
    void ThirdPosition()
    {
        LeftHandDis = Vector3.Distance(original.LeftHand.transform.position, copied3.LeftHand.transform.position);
        RightHandDis = Vector3.Distance(original.RightHand.transform.position, copied3.RightHand.transform.position);
        LeftFootDis = Vector3.Distance(original.LeftFoot.transform.position, copied3.LeftFoot.transform.position);
        RightFootDis = Vector3.Distance(original.RightFoot.transform.position, copied3.RightFoot.transform.position);

        if (copied3.ThirdModel.activeSelf == true)
        {

            if (LeftHandDis > OriginalToThird - 0.2f && LeftHandDis < OriginalToThird + 0.15f &&
               RightHandDis > OriginalToThird - 0.2f && original.RightHand.transform.position.y >= ThirdY+0.85f &&
               LeftFootDis > OriginalToThird - 0.2f && LeftFootDis < OriginalToThird + 0.15f)
            {
                copied3.ThirdModel.SetActive(false);
                ThirdToFinishBtn.SetActive(true);

            }

        }
        if (Input.GetKey(KeyCode.O))
            Debug.Log("Third LeftHandDis : " + LeftHandDis);
        if (Input.GetKey(KeyCode.P))
            Debug.Log("Third RightHandDis : " + RightHandDis);
        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("Third LeftFootDis : " + LeftFootDis);
            Debug.Log("Third RightHand.y : " + original.RightHand.transform.position.y);
            Debug.Log("Third ThirdY : " + ThirdY);
        }
    }

}
