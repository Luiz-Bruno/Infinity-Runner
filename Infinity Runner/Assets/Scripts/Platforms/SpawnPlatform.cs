using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>(); //Lista dos Prefabs das plataformas

    private List<Transform> currentPlatforms = new List<Transform>(); //Lista das plataformas geradas na cena

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, -4.5f), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
           
    }

    private void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x; //Salvando a diferen�a da posi��o x do player e do final point da plataforma atual

        if (distance >= 1) //Se o distance for maior do que 1, recicla a plataforma (ou seja, envia pra frente)
        {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;

        }

    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, -4.5f);

        if(platform.GetComponent<Platform>().spawnObj != null)
        {
           platform.GetComponent<Platform>().spawnObj.Spawn();
        }
        
        offset += 30f;
    }

}
