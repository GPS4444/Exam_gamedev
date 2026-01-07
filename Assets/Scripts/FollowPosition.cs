using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3 (target.position.x + offset.x, offset.y, target.position.z + offset.z);
    }
}
