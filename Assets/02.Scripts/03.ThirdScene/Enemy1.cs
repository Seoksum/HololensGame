using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Enemy1()
    {
        Debug.Log("Enemy1 »ý¼º");
    }
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Attack { get; set; }

    public void Damaged(int damage)
    {
        Hp -= damage;
    }
    public bool IsDied;
}
