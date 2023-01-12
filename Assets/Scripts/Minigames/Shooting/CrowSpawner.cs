using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSpawner : MonoBehaviour
{
    private float spawnTimer;
    public float spawnDuration;
    public CrowPool pool;
    public float yMin;
    public float yMax;

    public List<Transform> targetPosition;


    // Update is called once per frame
    void Update()
    {
        spawnTimer -= 1 * Time.deltaTime;
        if (spawnTimer <= 0)
        {
            GameObject target = pool.GetPooledObject();
            if (target != null)
            {
                target.transform.position = new Vector3(targetPosition[Random.Range(0, targetPosition.Count)].position.x, Random.Range(yMin,yMax), targetPosition[Random.Range(0, targetPosition.Count)].position.z);
                target.SetActive(true);
            }
            /*var newTarget = Instantiate(targetPrefab, targetPosition.position, Quaternion.identity);
            newTarget.transform.parent = gameObject.transform;*/
            spawnTimer = spawnDuration;

        }
    }
}
