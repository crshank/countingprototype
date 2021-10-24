using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody footballRb;
    private float force = 35.0f;
    private SpawnManager spawnManager;
    private bool spawnedNext = false;

    // Start is called before the first frame update
    void Start()
    {
        footballRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("Spawn Manager").
            GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If football passes x=0, spawn a new football
        // unless it has already spawned another football
        if (transform.position.x < 0)
        {
            if (spawnedNext == false)
            {
                spawnManager.SpawnFootball();
                spawnedNext = true;
            }
            
        }
    }

    private void OnMouseDown()
    {
        //Raycast helps to "aim" the kick
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // Find the line from the gun to the point that was clicked.
            Vector3 incomingVec = hit.point - footballRb.position;

            // Use the point's normal to calculate the reflection vector.
            Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);

            footballRb.AddForce(reflectVec * force, ForceMode.Impulse);

        }

    
    }
}
