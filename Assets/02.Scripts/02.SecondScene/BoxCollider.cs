using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour
{

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("�浹");
            this.gameObject.SetActive(false);
        }
    }
}
