using UnityEngine;
using UnityEngine.UIElements;

public class CharacterControllerPlayer : MonoBehaviour
{
    public BulletsManager bulletsManager;
    public GameManager gameManager;

    [SerializeField] Camera gameCamera;
    [SerializeField] float pSpeed;
    [SerializeField] float pHeight;
    [SerializeField] float floatingSpeed;
    [SerializeField] float floatingHeight;

    private Vector3 direction;
    public static Ray mouseRay;
    private float horizontalInput;
    private float verticalInput;
    private float turnAngle;

    void Start()
    {
        ResetPlayer();
    }

    void Update()
    {   
        //move player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        direction = new (horizontalInput, 0, verticalInput);

        //limit player movement to bounds
        if (transform.position.x > gameManager.mapSizeX && horizontalInput > 0)
            direction.x = 0;
        else if (transform.position.x < - gameManager.mapSizeX && horizontalInput < 0)
            direction.x = 0;
        if (transform.position.z > gameManager.mapSizeZ && verticalInput > 0)
            direction.z = 0;
        else if (transform.position.z < - gameManager.mapSizeZ && verticalInput < 0)
            direction.z = 0;

        transform.Translate(pSpeed * Time.deltaTime  * direction.normalized, Space.World);

        //floating (strange sin behaviour, not returning -1 apparently)
        direction = new (0, Mathf.Sin(Time.time * floatingSpeed) * floatingHeight, 0);

        transform.Translate(direction * Time.deltaTime, Space.World);

        //rotate player towards mouse
        mouseRay = gameCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit raycastHit))
            turnAngle = Functions.VectorToAngle(Functions.PointToVector(raycastHit.point, transform.position));

        transform.rotation = Quaternion.Euler(0, turnAngle, 0);

        //change bullet colour by pressing space
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            bulletsManager.ChangeColourIndex(1);
        }
        
        if (Input.GetMouseButtonDown(0) && BulletsManager.bCounter > 0)
        {
            bulletsManager.ShotBullet();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blue") || other.CompareTag("Green") || other.CompareTag("Magenta"))
            gameManager.GameOver();
    }

    public void ResetPlayer()
    {
        transform.position = new (0, pHeight, 0);
    }
}
