using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    Pool pool;
    float activeTime;
    float activeTimeRate = 2.0f;
    GameObject firePos;

    void Start()
    {
        firePos = GameObject.Find("FirePos");
    }

    // Update is called once per frame
    void Update()
    {
        activeTime -= Time.deltaTime;
        if (activeTime > 0)
        {
            transform.position += new Vector3(0, 0, 1.0f);
        }
        else
        {
            pool.Enqueue(gameObject);
        }
    }
    public void Init(Pool _pool)
    {
        pool = _pool;
    }

    public void CleanUp()
    {
        activeTime = activeTimeRate;
    }
    public void BulletObj()
    {
        pool.Enqueue(gameObject);
    }
}
