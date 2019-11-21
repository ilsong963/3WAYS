using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetspawn : MonoBehaviour
{
    public GameObject[] missileprefab = new GameObject[3];
    public float spawnRateMin = 10f;
    public float spawnRateMax = 20f;

    private float spawnRate;
    private float timeAfterSpawn;

    float startdelay = 3f;
    float time;
    int planetnum;
    // Start is called before the first frame update

    void Start()
    {
       
    }
    void init()
    {
        planetnum = Random.Range(0, 3);
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > startdelay)
        {
            planetnum = Random.Range(0, 3);
            timeAfterSpawn += Time.deltaTime;


            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                GameObject missile = Instantiate(missileprefab[planetnum], transform.position, transform.rotation);
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
    }
}
