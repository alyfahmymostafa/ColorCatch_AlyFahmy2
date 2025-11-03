using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    public Transform player; // Assign your Player object here in the Inspector
    public float chaseRange = 30f; // How far the enemy can detect the player
    public float catchDistance = 1.5f; // Distance to trigger game over

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            // Try to automatically find player if not assigned
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogError("EnemyAI: No Player found! Assign it in the Inspector or tag your player as 'Player'.");
        }
    }

    void Update()
    {
        if (player == null || GameManager.instance == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Only chase if player is within range
        if (distanceToPlayer <= chaseRange)
        {
            agent.SetDestination(player.position);
        }

        // If close enough to the player → Game Over
        if (distanceToPlayer <= catchDistance)
        {
            Debug.Log("Player caught by enemy!");
            GameManager.instance.EndGame();
        }
    }
}
