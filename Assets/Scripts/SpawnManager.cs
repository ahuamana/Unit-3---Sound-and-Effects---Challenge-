using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    public float startDelay = 2;
    public float repeatRate = 2;

    private PlayerController playerControllerScript;

    void Start()
    {
       
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void SpawnObstacle()
    {
        
        var index = genRamdon();

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
            //Debug.Log("Instanciando objeto con el indice:" + index);
        }
        
    }

    //Generate random number
    int genRamdon()
    {
        var ran =Random.Range(0, 3);
        return ran;
    }
}
