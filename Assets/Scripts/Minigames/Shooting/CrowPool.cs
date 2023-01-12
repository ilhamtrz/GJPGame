using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowPool : MonoBehaviour
{
    private List<GameObject> pooledObjects = new List<GameObject>();
    public int amountToPool = 20;

    [SerializeField] private GameObject targetPrefab;
    // Start is called before the first frame update

    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(targetPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.parent = gameObject.transform;
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
