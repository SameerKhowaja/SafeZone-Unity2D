using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public GameObject coinObj;
    GameObject coin;
    public Transform playerPos, point;
    public playerMovement pm;
    float startTime, btwnTime, tempTime;
    int tempPoints;

    void Start()
    {
        startTime = 1f;
        btwnTime = 10f;
        tempPoints = pm.points;
    }

    void Update()
    {
        //tempTime = startTime + btwnTime;
        if (Time.time >= startTime)
        {
            pointsCoinSpawn();
            startTime = Time.time + btwnTime;
        }

        if (tempPoints < pm.points)
        {
            pointsCoinSpawn();
            tempPoints = pm.points;
            startTime = Time.time + btwnTime;
        }

        Destroy(coin, btwnTime);
    }

    void pointsCoinSpawn()
    {
        //Debug.Log(-playerPos.position);
        point.position = -playerPos.position;
        if (point.position.x < 1f && point.position.x > -1f || point.position.y < -1f && point.position.y > 1f)
        {
            point.position = new Vector3(Random.Range(-2f,5f) , Random.Range(-2f, 3f), 0f);
        }

        coin = Instantiate(coinObj, point.position, Quaternion.identity);
    }

    

}
