using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
where T : IPoolClient // le type de T doit avoir implementer IPoolClint
{
    private GameObject anchor;
    private GameObject prefab;
    private Queue<T> queue = new();
    private int batch;

    public Pool(GameObject anchor, GameObject prefab, int batch)
    {
        this.anchor = anchor;
        this.prefab = prefab;
        this.batch = batch;

        CreateBatch();
    }

    private void CreateBatch()
    {
        for (int _ = 0; _ < batch; _++)
        {
            GameObject go = GameObject.Instantiate(prefab);
            if (go.TryGetComponent(out T client))
            {
                Add(client);
            }
            else
            {
                throw new ArgumentException("Prefab doesn't have a IPoolClient component");
            }
        }
    }

    public void Add(T client)
    {
        queue.Enqueue(client);
        client.fall();
    }

    public T Get(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        if (queue.Count == 0) CreateBatch();
        
        T client = queue.Dequeue();
        // client.Appear(anchor.transform.position, anchor.transform.rotation);
        client.Appear(spawnPosition, spawnRotation);
        return client;
    }
}