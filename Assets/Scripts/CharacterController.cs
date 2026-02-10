using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{ 
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
        transform.position = new (0, pHeight, 0);
    }

    void Update()
    {   
        //move player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        direction = new (horizontalInput, 0, verticalInput);

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
            print(BulletsManager.bColourIndex);
            BulletsManager.ChangeColourIndex(1);
        }
    }
}
