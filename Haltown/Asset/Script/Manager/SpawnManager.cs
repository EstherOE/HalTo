using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerMovement movement;

    public GameObject enemyPrefab;


    public static SpawnManager instance;
    float zaxisOne = -53.2f;
    float zaxisTwo= -9f;
    float xaxisOne = -6.8f;
    float xaxisTwo = 18.9f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        movement = FindObjectOfType<PlayerMovement>();

        int number = Random.Range(1, 10);


       SpawnZombie(number);

    }



    Vector3 SpanPos()
    {

        return new Vector3(Random.Range(xaxisOne,xaxisTwo), 0.3f,Random.Range(zaxisOne,zaxisTwo));
    }
    float spawnRate = 30f;
   public  void SpawnZombie(int number)
    {

        for (int i = 0; i <= number; i++)
        {

            Instantiate(enemyPrefab, SpanPos(), enemyPrefab.transform.rotation);

        }
    }
}
