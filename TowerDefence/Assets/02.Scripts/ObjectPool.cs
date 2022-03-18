using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public static ObjectPool Instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<ObjectPool>("ObjectPool"));
            return _instance;
        }
    }
    List<PoolElement> poolElements = new List<PoolElement>();
    List<GameObject> spawnedObjects = new List<GameObject> ();
    Dictionary<string, Queue<GameObject>> spawnedQueueDictionrary = new Dictionary<string, Queue<GameObject>>();

    public void AddPoolElement(PoolElement poolElement)
    {
        poolElements.Add(poolElement);
        Debug.Log($"{poolElement.tag} is added on ObjectPool");
    }

    private void Start()
    {
        foreach(PoolElement poolElement in poolElements)
        {
            spawnedQueueDictionrary.Add(poolElement.tag, new Queue<GameObject>());
            for (int i = 0; i < poolElement.size; i++)
            {
                GameObject obj = CreateNewObject(poolElement.tag, poolElement.prefab);
                ArrangePool(obj);
            }
        }
    }

    public static void ReturnToPool(GameObject obj)
    {
        if (!Instance.spawnedQueueDictionrary.ContainsKey(obj.name))
            throw new Exception($"Pool doesn't include {obj.name}");
        Instance.spawnedQueueDictionrary[obj.name].Enqueue(obj);
    }

    public static int GetSpawndObjerctNumber(string tag)
    {
        int count = 0;
        foreach(var go in Instance.spawnedObjects)
        {
            if (go.name == tag &&
                go.activeSelf)
                count++;
        }
        return count;
    }

    public static GameObject SpawnFromPool(string tag, Vector3 position) =>
        Instance.Spwan(tag, position);

    private GameObject Spwan(string tag, Vector3 position)
    {
        if (!spawnedQueueDictionrary.ContainsKey(tag))
            throw new System.Exception($"Pool dosen't contanis {tag}");

        Queue<GameObject> queue = spawnedQueueDictionrary[tag];
        if(queue.Count == 0)
        {
            PoolElement poolElement = poolElements.Find(x => x.tag == tag);
            var obj= CreateNewObject(poolElement.tag, poolElement.prefab);
            ArrangePool(obj);
        }
        GameObject objectToSpawn = queue.Dequeue();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = Quaternion.identity;
        objectToSpawn.SetActive(true);
        return objectToSpawn;
    }

    private GameObject CreateNewObject(string tag, GameObject prefab)
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.name = tag;
        obj.SetActive(false);
        return obj;
    }

    private void ArrangePool(GameObject obj)
    {
        bool isSameObjectExist = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if(i == transform.childCount - 1)
            {
                obj.transform.SetSiblingIndex(i);
                spawnedObjects.Insert(i, obj);
                break;
            }
            else if (transform.GetChild(i).name == obj.name)
            {
                isSameObjectExist = true;
            }
            else if (isSameObjectExist)
            {
                obj.transform.SetSiblingIndex(i);
                spawnedObjects.Insert(i, obj);
                break;
            }
        }
    }
}

[System.Serializable]
public class PoolElement
{
    public string tag;
    public GameObject prefab;
    public int size;
}
