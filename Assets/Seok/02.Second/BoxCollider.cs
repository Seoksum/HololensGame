using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour
{

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")//&&obstacle.Length>=0)
        {
            Debug.Log("Ãæµ¹");
            this.gameObject.SetActive(false);
        }
        //FSM();
    }
}
