using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject football;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnFootball();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //Spawn a new football at the same starting position
    public void SpawnFootball()
    {
        Vector3 spawnPos = new Vector3(10, 1, 0);
        Instantiate(football, spawnPos, football.transform.rotation);
    }

}
