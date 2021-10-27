using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{

    public int speed = 10;
    public GameObject human;
    private Rigidbody humanRb;
    public float gravityModifer = 1.0f;
    public float jumpForce = 1500.0f;
    private bool isOnGround;
    private float humanZLimit = 3.0f;
    private float humanXLimit = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifer;
        humanRb = human.GetComponent<Rigidbody>();
        HumanMovement();
    }

    // Update is called once per frame
    void Update()
    {
        ConstrainHuman();
    }

    public void Movement()
    {

    }

    private void HumanMovement()
    {
        humanRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
        if (human.transform.position.x >= humanXLimit / 3.0f)
        {
            human.transform.position = new Vector3(humanXLimit / 3.0f,
                transform.position.y, transform.position.z);
        }
        if (human.transform.position.x <= humanXLimit)
        {
            human.transform.position = new Vector3(humanXLimit,
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
