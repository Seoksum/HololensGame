using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class JsonManager : MonoBehaviour
{
    public PlayerInfo _info;

    void Start()
    {
        
    }

    //[ContextMenu("To Json Data")]
    public void SavePlayerDataToJsons()
    {
        string jsonData = JsonUtility.ToJson(_info, true);
        string path = Path.Combine(Application.dataPath, "TimeInfo.json");//���� �������� ����Ƽ ������Ʈ
        File.WriteAllText(path, jsonData);
    }

    //[ContextMenu("From Json Data")]
    void loadPlayerDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "TimeInfo.json");//���� �������� ����Ƽ ������Ʈ
        string jsonData = File.ReadAllText(path);
        _info = JsonUtility.FromJson<PlayerInfo>(jsonData);//������ȭ
        
    }
    void Update()
    {
        //_timer = GetComponent<StageTimer>().UpdateInfo();
    }
}

[System.Serializable]
public class PlayerInfo
{
    public string name;
    public static int flowerNum = 1;
    public static int hp = new Player().Hp;
    public float time;
    public int TotalScore;
}