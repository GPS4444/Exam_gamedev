using UnityEngine;

public class BulletShot : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] int baseDamage = 1;
    [SerializeField] int critMultiplier = 2;
    private Rigidbody rb;
    private Transform player;
    private CharacterControllerPlayer characterControllerPlayer;
    private ParticleSystem particles;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        transform.SetParent(null);

        particles = GetComponentInChildren<ParticleSystem>();
        particles.Play();
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * bulletSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);

        if (other.CompareTag("Blue") || other.CompareTag("Green") || other.CompareTag("Magenta"))
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();
            if (other.tag == this.tag)
                enemy.TakeDamage(baseDamage * critMultiplier);    
            else
                enemy.TakeDamage(baseDamage);
        }
    }
}



    //Old code
    
    // private Vector3 CalculatePlayerVelocity(Vector3 pastPos)
    // {
    //     Vector3 velocity = player.transform.position - pastPos;
    //     return velocity;
    // }