using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSpawner : MonoBehaviour
{
    private float spawnTimer;
    public float spawnDuration;
    public CrowPool poolLeft;
    public CrowPool poolRight;
    public float yMin;
    public float yMax;

    public List<Transform> targetPosition;


    // Update is called once per frame
    void Update()
    {
        spawnTimer -= 1 * Time.deltaTime;
        if (spawnTimer <= 0)
        {
            GameObject targetLeft = poolLeft.GetPooledObject();
            if (targetLeft != null)
            {
                targetLeft.transform.position = new Vector3(targetPosition[0].position.x, Random.Range(yMin,yMax), targetPosition[0].position.z);
                targetLeft.SetActive(true);
            }
            GameObject targetRight = poolRight.GetPooledObject();
            if (targetRight != null)
            {
                targetRight.transform.position = new Vector3(targetPosition[1].position.x, Random.Range(yMin, yMax), targetPosition[1].position.z);
                targetRight.SetActive(true);
            }
            /*var newTarget = Instantiate(targetPrefab, targetPosition.position, Quaternion.identity);
            newTarget.transform.parent = gameObject.transform;*/
            spawnTimer = spawnDuration;

        }
    }
}
