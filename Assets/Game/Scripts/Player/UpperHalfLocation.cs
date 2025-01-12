using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; 

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
        }
    }
}
