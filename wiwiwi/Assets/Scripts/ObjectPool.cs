using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool {
    private List<GameObject> pooledObjects;
    private GameObject objectToPool;
    private int amountToPool;
    // Start is called before the first frame update

    public ObjectPool(GameObject objectToPool, int amountToPool)
    {
        this.objectToPool = objectToPool;
        this.amountToPool = amountToPool;

        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = GameObject.Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject getObject() {
        for (int i = 0; i < pooledObjects.Count; i++) if (!pooledObjects[i].activeSelf) return pooledObjects[i];
        return null;
    }
}
