using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float floatingHeight;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody>();
        rb.position = new (transform.position.x, floatingHeight, transform.position.z);
    }

    void Update()
    {
        //move towards player
        Vector3 toTarget = (player.transform.position - transform.position).normalized;
        toTarget = toTarget * speed;
        toTarget.y = 0; 

        rb.linearVelocity = toTarget;
        
        //turn towards player
        rb.rotation = Quaternion.Euler(0, Functions.VectorToAngle(toTarget), 0);
    }   
}