using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 toTarget = (target.transform.position - transform.position).normalized;
        toTarget.y = 0; 
        transform.Translate(speed * Time.deltaTime * toTarget);
    }
}
