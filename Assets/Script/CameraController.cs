using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    // Follow player camera
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    // Added: Smoothing follow camera
    [SerializeField] private float followSmoothTime = 0.1f;
    private Vector3 cameraVelocity = Vector3.zero;

    private void Update()
    {
        // Room camera
        // Gradually changes a vector towards a desired goal over time.
        // transform.position = Vector3.SmoothDamp(transform.position, 
        //     new Vector3(currentPosX, transform.position.y, transform.position.z),
        //     ref velocity, speed);

        // Follow player camera with smoothing to reduce sudden movements
        Vector3 targetPosition = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, followSmoothTime);

        // Gradually adjust look ahead distance
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
