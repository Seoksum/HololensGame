using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    //[SerializeField] Transform firePos;
    //[SerializeField] Pool pool;

    public GameObject[] obstacle;
    GameObject nowObstacle;
    int nowObstacleIdx = 0;
    int count;
    int cubeCount = 4;

    public GameObject NextStageCanvas;
    public GameObject flower;
    public Countdown _countDown;

    int dir = 1;
    float currentPosX;
    float currentPosY;
    int scope = 2;
    float speed = 3.0f;

    void Start()
    {
        nowObstacleIdx = 0;
        nowObstacle = obstacle[nowObstacleIdx];
        currentPosX = nowObstacle.transform.localPosition.x;
        currentPosY = nowObstacle.transform.localPosition.y;
    }


    void Update()
    {
        if (nowObstacle.activeSelf)
        {
            if (nowObstacleIdx % 2 == 0)
            {
                LeftRightMove(nowObstacle, currentPosX);
            }
            else
            {
                UpDownMove(nowObstacle, currentPosY);
            }
        }

        else // nowObstacle.activeSelf == false
        {
            if (nowObstacleIdx < cubeCount)
            {
                nowObstacle = obstacle[++nowObstacleIdx];
                currentPosX = nowObstacle.transform.localPosition.x;
                currentPosY = nowObstacle.transform.localPosition.y;
                nowObstacle.SetActive(true);
            }
            else
            {
                NextStageCanvas.SetActive(true);
                flower.SetActive(true);
                _countDown.StopPlaying();
            }
        }
    }

    // 큐브 왼,오른으로 움직이기
    void LeftRightMove(GameObject obj, float currentPos)
    {
        if (obj.transform.localPosition.x > currentPos + scope)
            dir = 1;

        else if (obj.transform.localPosition.x < currentPos - scope)
            dir = -1;

        obj.transform.Translate(Vector3.left * dir * Time.deltaTime * speed);
    }

    // 큐브 위,아래로 움직이기
    void UpDownMove(GameObject obj, float currentPos)
    {
        if (obj.transform.localPosition.y > currentPos + scope)
            dir = 1;

        else if (obj.transform.localPosition.y < currentPos - scope)
            dir = -1;

        obj.transform.Translate(Vector3.down * dir * Time.deltaTime * speed);
    }
}
