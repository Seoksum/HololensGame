using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    Pool pool;
    float activeTime = 2.0f;
    float activeTimeRate = 2.0f;
    //public GameObject gameObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeTime -= Time.deltaTime;
        if (activeTime > 0)
        {
            transform.position += new Vector3(0, 0, 0.1f);
        }
        else
        {
            pool.OnReturnedToPool(gameObject);
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
        pool.OnReturnedToPool(gameObject);
    }
}
