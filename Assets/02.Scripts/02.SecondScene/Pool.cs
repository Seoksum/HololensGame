using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject poolableObject;
    public int objectpoolCount = 10;
    Queue<GameObject> objectPool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectpoolCount; i++)
        {
            CreatePooledObject();
        }
    }

    void CreatePooledObject()
    {
        GameObject temp = Instantiate(poolableObject);
        
        temp.GetComponent<Poolable>().Init(this);
        temp.SetActive(false);
        objectPool.Enqueue(temp);
    }

    // Get Object
    public GameObject Dequeue()
    {
        if (objectPool.Count <= 0)
        {
            CreatePooledObject();
        }

        GameObject dequeueObject = objectPool.Dequeue();
        dequeueObject.GetComponent<Poolable>().CleanUp();
        dequeueObject.SetActive(true);
        return dequeueObject;
    }
    // Back to pool
    public void Enqueue(GameObject _enqueueObject)
    {
        _enqueueObject.SetActive(false);
        objectPool.Enqueue(_enqueueObject);
    }
}
