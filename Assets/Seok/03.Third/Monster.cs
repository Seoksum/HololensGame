using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour { 


}
public class Enemy 
{
    public Enemy()
    {
        Debug.Log("Enemy »ý¼º");
    }
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Attack { get; set; }

    public void Damaged(int damage)
    {
        Hp -= damage;
    }
   
}

public class Player
{
    private string name;
    private int hp = 500;
    private int attack;

    public string Name { get; set; }
    public int Hp { get; set; }
    public int Attack { get; set; }

    public void Damaged(int damage)
    {
        hp -= damage;
    }
    
}

