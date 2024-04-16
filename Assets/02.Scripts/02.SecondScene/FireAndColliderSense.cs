using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FireAndColliderSense: MonoBehaviour
{
    [SerializeField] Transform firePos;
    [SerializeField] Pool pool;

    public GameObject[] obstacle;
    GameObject nowObstacle;
    int i = 0;
    int count;

    public GameObject NextStageCanvas;
    public GameObject flower;
    //public PlayerInfo _info;
    public Countdown _countDown;

    int dir = 1;
    float currentPosX;
    float currentPosY;

    void Start()
    {
        nowObstacle = obstacle[0];
        count = 1;
        currentPosX = nowObstacle.transform.localPosition.x;
        currentPosY = nowObstacle.transform.localPosition.y;
    }

    public void GameStart()
    {
        _countDown.m_IsPlaying = true;
    }


    void Update()
    {
        if (count % 2 == 0)
            LeftRightMove(nowObstacle, currentPosX);
        else
            UpDownMove(nowObstacle, currentPosY);

        if (nowObstacle.activeSelf == false && i<=3)
        {
            nowObstacle = obstacle[++i];
            currentPosX = nowObstacle.transform.localPosition.x;
            currentPosY = nowObstacle.transform.localPosition.y;
            nowObstacle.SetActive(true);
            count++;
        }

        if(obstacle[3].activeSelf==false && i==4)
        {
            //SceneManager.LoadScene("ThirdScene");
            NextStageCanvas.SetActive(true);
            flower.SetActive(true);
            //PlayerInfo.flowerNum++;
            _countDown.StopPlaying();
        }
    }

    public void fireBullet()
    {
        GameObject pooledObject = pool.Dequeue();
        pooledObject.transform.position = firePos.transform.position;
        Vector3 dis = (nowObstacle.transform.position - pooledObject.transform.position ).normalized;
        pooledObject.transform.Translate(Vector3.forward * 3f*Time.deltaTime);
    }


    void LeftRightMove(GameObject obj,float currentPos)
    {
        int scope = 2; 
        float speed = 3.0f;
        
        if(obj.transform.localPosition.x > currentPos + 2)
            dir = 1;

        else if(obj.transform.localPosition.x < currentPos - 2)
            dir = -1;

        obj.transform.Translate(Vector3.left * dir * Time.deltaTime * speed);
    }

    void UpDownMove(GameObject obj, float currentPos)
    {
        int scope = 2;
        float speed = 3.0f;

        if (obj.transform.localPosition.y > currentPos + 2)      
            dir = 1;
        
        else if (obj.transform.localPosition.y < currentPos - 2)     
            dir = -1;
        
        obj.transform.Translate(Vector3.down * dir * Time.deltaTime * speed);
    }
}
