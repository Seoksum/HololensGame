using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Enemy() { Debug.Log("Enemy »ý¼º"); }
    public int Hp { get; set; }
    public bool IsDied;
    public void Damaged(int damage)
    {
        Hp -= damage;
    }
}
