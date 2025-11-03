using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // Player to follow
    public Vector3 offset = new Vector3(0, 8, -12); // Fixed offset from the player
    public float smoothSpeed = 0.1f;  // How fast the camera catches up

    void LateUpdate()
    {
        if (player == null) return;

        // Desired position is always the player's position + fixed offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move camera to desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Make camera look at the player slightly above center
        transform.LookAt(player.position + Vector3.up * 2f);
    }
}
