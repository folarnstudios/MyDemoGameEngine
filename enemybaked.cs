using UnityEngine;
using UnityEngine.AI;

public class EnemySmoothAI : MonoBehaviour
{
    [Header("Target")]
    public Transform player;
    public float stoppingDistance = 1.5f; // Distance to stop from player

    [Header("Components")]
    private NavMeshAgent agent;
    private Animator anim;

    [Header("Animation")]
    public string speedParameter = "speed"; // Animator float parameter name

    [Header("Rotation")]
    public float rotationSpeed = 5f; // How fast enemy turns toward player

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        // Root Motion must be OFF
        anim.applyRootMotion = false;

        // Configure NavMeshAgent
        agent.stoppingDistance = stoppingDistance;
        agent.updateRotation = false; // We'll handle rotation manually
        agent.updateUpAxis = true;
    }

    void Update()
    {
        if (player == null) return;

        // Set NavMeshAgent destination
        agent.SetDestination(player.position);

        // Smooth rotation toward player if far enough
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        if (direction.magnitude > stoppingDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // Calculate movement speed for animation
        Vector3 velocity = agent.velocity;
        velocity.y = 0;
        float speed = velocity.magnitude / agent.speed; // normalize 0-1
        anim.SetFloat(speedParameter, speed);
    }
}
