using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    public int speed = 1;
    public GameObject bird;
    private Rigidbody birdRb;
    public float gravityModifer = 1.0f;
    public float jumpForce = 100.0f;
    public bool forward = true;
    private float xLimit = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifer;
        birdRb = bird.GetComponent<Rigidbody>();
        BirdMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
        BirdMovement();
    }

    private void BirdMovement()
    {
        if (forward == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (forward == false)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        if (bird.transform.position.y <= 3)
        {
            birdRb.AddForce(Vector3.up * 2.0f, ForceMode.Impulse);
        }

        
        if (bird.transform.position.z >= 45)
        {
            forward = false;
            
        }
        if (bird.transform.position.z <= -10)
        {
            forward = true;
        }
    }

    private void ConstrainBird()
    {
        if (bird.transform.position.z >= 60.0f)
        {
            bird.transform.position = new Vector3(transform.position.x,
                transform.position.y, 59.0f);
        }
        if (bird.transform.position.z <= -20.0f)
        {
            bird.transform.position = new Vector3(transform.position.x,
                transform.position.y, -19.0f);
        }
        if (bird.transform.position.x >= xLimit)
        {
            bird.transform.position = new Vector3(xLimit,
                transform.position.y, transform.position.z);
        }
        if (bird.transform.position.x <= -xLimit)
        {
            bird.transform.position = new Vector3(-xLimit,
                transform.position.y, transform.position.z);
        }
        if (bird.transform.position.y >= 15.0f)
        {
            bird.transform.position = new Vector3(transform.position.x,
                15.0f, transform.position.z);
        }
    }
}