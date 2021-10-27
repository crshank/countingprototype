using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject football;
    public GameObject human;
    public GameObject bird;


    // Start is called before the first frame update
    void Start()
    {
        SpawnFootball();
        SpawnBird();
        SpawnHuman();
    }

    //Spawn a new football at the starting position
    public void SpawnFootball()
    {
        Vector3 spawnPos = new Vector3(10, 1, 0);
        Instantiate(football, spawnPos, football.transform.rotation);
    }

    public void SpawnBird()
    {
        Vector3 spawnPos = new Vector3(0, 3.36f, -12.0f);
        Instantiate(bird, spawnPos, bird.transform.rotation);
    }


    public void SpawnHuman()
    {
        Vector3 spawnPos = new Vector3(-10, 4f, 0f);
        Instantiate(human, spawnPos, bird.transform.rotation);
    }

}
