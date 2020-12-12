using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed;

    void FixedUpdate(){
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
