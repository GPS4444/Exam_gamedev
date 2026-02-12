using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public static float speed = 5;
    [SerializeField] float enemySpeed = 5;
    [SerializeField] float floatingHeight;
    [SerializeField] int healthPoints = 2;

    private GameObject player;
    private Rigidbody rb;
    private ParticleSystem[] particles;

    void Start()
    {
        speed = enemySpeed;
        
        player = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody>();
        rb.position = new (transform.position.x, floatingHeight, transform.position.z);

        particles = GetComponentsInChildren<ParticleSystem>();
        particles[0].Play();
        particles[1].Play();
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

        //reset height
        rb.position = new (transform.position.x, floatingHeight, transform.position.z);
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            GameManager.enemiesDefeated += 1;
        }
    }
}