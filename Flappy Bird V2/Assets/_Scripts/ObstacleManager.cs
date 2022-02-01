using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacle;
    [SerializeField] private Transform baseSpawnLocation;
    [SerializeField] private float ySpawnRange;
    [SerializeField] private float spawnRate;
    
    private WaitForSeconds Wait;

    private void Start() {
        Wait = new WaitForSeconds(spawnRate);

        StartCoroutine(SpawnObstacle());
    }   

    private Vector3 NewPosition()
    {
        return baseSpawnLocation.position + Vector3.up * Random.Range(-ySpawnRange,ySpawnRange);
    }
    IEnumerator SpawnObstacle()
    {
        while(true)
        {
            yield return Wait; 
            int index = Random.Range(0,Obstacle.Length);
            Instantiate(Obstacle[index],NewPosition(),Obstacle[index].transform.rotation);
            SpawnObstacle();
        }
    }

    public void FinishGame()
    {
        Object[] constantMovers = FindObjectsOfType<ConstantMovement>();
        Object[] repeatingMovers = FindObjectsOfType<RepeatingScrolling>();

        foreach (ConstantMovement item in constantMovers)
        {
            item.enabled=false;
        }

        foreach (RepeatingScrolling item in repeatingMovers)
        {
            item.enabled = false;
        }
        
        StopAllCoroutines();
        this.enabled=false;
    }

    

    

    
}
