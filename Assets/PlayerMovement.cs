using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // how fast the player moves
    Rigidbody rb; // to control the player’s physics

    void Start()
    {
        // get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // get keyboard input: left/right (A-D or arrows)
        float moveX = Input.GetAxis("Horizontal");

        // get keyboard input: forward/backward (W-S or arrows)
        float moveZ = Input.GetAxis("Vertical");

        // create a movement direction based on input
        Vector3 movement = new Vector3(moveX, 0, moveZ);

        // move the player by changing its position
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
}
