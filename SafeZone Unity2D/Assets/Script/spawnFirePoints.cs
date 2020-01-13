using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFirePoints : MonoBehaviour
{
    public Transform[] points;
    public GameObject prefab;
    public Transform playerLoc;
    int randomPointsSelect1;
    float gap = 1f;
    float wavesGab;
    
    void FixedUpdate()
    {
        randomPointsSelect1 = Random.Range(0,points.Length);
        wavesGab = Random.Range(0.5f, 1f);
        if (Time.time >= gap)
        {
           Instantiate(prefab, points[randomPointsSelect1].position, Quaternion.identity);
           gap = Time.time + wavesGab;
        }  
    }


}
