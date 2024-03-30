using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    private float speed;
    public float sprint;
    public float normalSpeed;

    //Jump
    private Rigidbody rb;
    public float jumpForce;
    private bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = normalSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;


        transform.Translate(Vector3.right * hInput);
        transform.Translate(Vector3.forward * vInput);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprint;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprint;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
