using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour, IMove
{
    [Header("References")]
    [SerializeField] private NavMeshAgent agent;

    private Vector3 velocity = Vector3.zero;

    public void Move(Vector3 destination)
    {
        agent.SetDestination(destination);

        //transform.position = Vector3.SmoothDamp(transform.position, agent.nextPosition, ref velocity, 0.1f);
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void Enable() { }
    public void Disable() { }
}