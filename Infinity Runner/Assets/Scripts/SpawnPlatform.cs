using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>(); //Lista dos Prefabs das plataformas

    private List<Transform> currentPlatforms = new List<Transform>(); //Lista das plataformas geradas na cena

    private Transform player;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, 0), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, 0f);
        offset += 30f;
    }

}
