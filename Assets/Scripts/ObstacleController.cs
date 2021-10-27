using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public int speed = 10;
    public GameObject comet;
    public GameObject human;
    public GameObject bird;
    private Rigidbody humanRb;
    private Rigidbody birdRb;
    public float gravityModifer = 1.0f;
    public float jumpForce = 1500.0f;
    private bool isOnGround;
    private float humanZLimit = 3.0f;
    private float humanXLimit = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifer;
        humanRb = human.GetComponent<Rigidbody>();
        birdRb = bird.GetComponent<Rigidbody>();
        HumanMovement();
        BirdMovement();
    }

    // Update is called once per frame
    void Update()
    {
        ConstrainHuman();
        BirdMovement();
    }

    public void Movement()
    {

    }

    private void HumanMovement()
    { 
        humanRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void BirdMovement()
    {
        if (bird.transform.position.y <= 3)
        {
            birdRb.AddForce(Vector3.up * 20.0f, ForceMode.Impulse);
        }
        if (bird.transform.position.z >= 60)
        {
            birdRb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        }
        if (bird.transform.position.z <= -20)
        {
            birdRb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        }
    }

    private void CometMovement()
    {
    }

    private void ConstrainHuman()
    {
        if (human.transform.position.z >= humanZLimit)
        {
            human.transform.position = new Vector3(transform.position.x,
                transform.position.y, humanZLimit);
        }
        if (human.transform.position.z <= -humanZLimit)
        {
            human.transform.position = new Vector3(transform.position.x,
                transform.position.y, -humanZLimit);
        }
        if (human.transform.position.x >= humanXLimit/3.0f)
        {
            human.transform.position = new Vector3(humanXLimit/3.0f,
                transform.position.y, transform.position.z);
        }
        if (human.transform.position.x <= -humanXLimit)
        {
            human.transform.position = new Vector3(-humanXLimit,
                transform.position.y, transform.position.z);
        }
    }

    private void ConstrainBird()
    {
        if (human.transform.position.z >= humanZLimit)
        {
            human.transform.position = new Vector3(transform.position.x,
                transform.position.y, humanZLimit);
        }
        if (human.transform.position.z <= -humanZLimit)
        {
            human.transform.position = new Vector3(transform.position.x,
                transform.position.y, -humanZLimit);
        }
        if (human.transform.position.x >= humanXLimit / 3.0f)
        {
            human.transform.position = new Vector3(humanXLimit / 3.0f,
                transform.position.y, transform.position.z);
        }
        if (human.transform.position.x <= -humanXLimit)
        {
            human.transform.position = new Vector3(-humanXLimit,
                transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            HumanMovement();
        }
    }
}
