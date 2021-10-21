using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemy;
    private int initAmount = 20;
    private float xPos1 = -0.17f;
    private float xPos2 = 8.25f;
    private float zPos = 0.2f;
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnAnimal();
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
    public void SpawnAnimal()
    {
        GameObject enemyPos = enemy[Random.Range(0, enemy.Count)];
        Instantiate(enemyPos, new Vector3(Random.Range(xPos1, xPos2), 0.51f, zPos), enemyPos.transform.rotation);
        Instantiate(enemyPos, new Vector3(Random.Range(xPos1, xPos2), 0.51f, zPos+1.5f), enemyPos.transform.rotation);
      

    }
}


