using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float speed = 10f;
    public float xRange = 20f;
    public float zRange = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Walk sideways
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Walk forward
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * (verticalInput * Time.deltaTime * speed));
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(-zRange, transform.position.x, transform.position.y);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(zRange, transform.position.x, transform.position.y);
        }

    }
}

