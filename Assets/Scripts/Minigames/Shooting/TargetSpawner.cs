using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    private float spawnTimer;
    public float spawnDuration;
    public TargetPool pool;

    public Transform targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawnTimer);
        spawnTimer -= 1 * Time.deltaTime;
        if(spawnTimer <= 0)
        {
            GameObject target = pool.GetPooledObject();
            if (target != null)
            {
                target.transform.position = targetPosition.position;
                target.SetActive(true);
            }
            /*var newTarget = Instantiate(targetPrefab, targetPosition.position, Quaternion.identity);
            newTarget.transform.parent = gameObject.transform;*/
            spawnTimer = spawnDuration;
            
        }
    }
}
