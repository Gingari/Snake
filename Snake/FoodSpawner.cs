using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FoodSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject right; public GameObject left;
    public GameObject up; public GameObject down;
    private float xmin;
    private float xmax; private float ymin;
    private float ymax;
    void Start()
    {
        xmin = left.transform.position.x;
        xmax = right.transform.position.x; ymin = down.transform.position.y;
        ymax = up.transform.position.y;
        Spawn();
    }
    public void Spawn()
    {
        float randomX = Random.Range(xmin + 5, xmax - 5);
        float randomY = Random.Range(ymin + 5, ymax - 5);
        Vector2 spawnPosition = new Vector2(randomX, randomY); Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
