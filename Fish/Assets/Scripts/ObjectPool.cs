using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;

    public static ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();

    private int randomObjectIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                GameObject obj = Instantiate(objectPrefabs[i]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            randomObjectIndex = Random.Range(0, pooledObjects.Count);

            if (!pooledObjects[randomObjectIndex].activeInHierarchy)
            {
                return pooledObjects[randomObjectIndex];
            }
        }

        return null;
    }
}
