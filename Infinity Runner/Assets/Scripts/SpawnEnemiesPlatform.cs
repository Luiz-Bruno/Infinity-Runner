using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlatform : MonoBehaviour
{
    public GameObject enemyPrefab;

    public List<Transform> points = new List<Transform>();
    
    // Start is called before the first frame update
    void Start()
    {
        CreateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        int pos = Random.Range(0, points.Count);

        GameObject e = Instantiate(enemyPrefab, points[pos].position, points[pos].rotation);
    }
}
