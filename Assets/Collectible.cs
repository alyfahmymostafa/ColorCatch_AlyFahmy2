using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    public string color; // Set this in the Inspector for each prefab (e.g., "Blue" for Collectible_Blue)

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collectible triggered by: " + other.gameObject.name + " (Tag: " + other.tag + ")"); // Debug log

        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collected " + color + " collectible!"); // Debug log

            // Notify GameManager of the collection
            if (GameManager.instance != null)
            {
                GameManager.instance.CollectCollectible(color);
                // Destroy the collectible
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("GameManager instance is null! Ensure GameManager script is attached and active.");
            }
        }
        else
        {
            Debug.Log("Not the player - ignoring collision."); // Debug log
        }
    }
}