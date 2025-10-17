using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    //How smoothly the camera follows the player
    public float smoothSpeed = 5f;

    // Update is called once per frame
    void LateUpdate()
    {
        //Based on players position
        Vector3 desiredPosition = player.position + offset;

        //Move current position to desired position, Lerp makes the movement smooth
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        //Apply the position
        transform.position = smoothedPosition;
    }
}
