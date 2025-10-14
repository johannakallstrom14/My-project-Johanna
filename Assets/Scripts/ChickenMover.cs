using UnityEngine;

public class ChickenMover : MonoBehaviour
{

    private float speed = 2f;
    private float changeDirectionTime = 4f;
    private float moveArea = 20f;

    private float directionTimer; //Counts down until the chicken picks a random direction
    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickNewDirection();
        GetComponent<Animator>().Play("Chicken_003_walk");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement timer
        directionTimer -= Time.deltaTime;
        if(directionTimer <= 0f)
        {
            PickNewDirection();
        }

        //Move forward
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        //Keep within the area
        if (Mathf.Abs(transform.position.x) > moveArea || Mathf.Abs(transform.position.z) > moveArea)
        {
            direction = (Vector3.zero - transform.position).normalized;

        }
    }

    void PickNewDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1, 1)).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        directionTimer = Random.Range(1f, changeDirectionTime);
    }
}
