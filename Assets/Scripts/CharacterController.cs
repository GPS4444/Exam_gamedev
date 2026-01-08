using UnityEngine;

public class CharacterController : MonoBehaviour
{ 
    [SerializeField] Transform headBone;

    [Header("--- Variables")]
    [SerializeField] float speed;

    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        
    }

    void Update()
    {   
        //player moves
        //fix speed while going diagonal
        horizontalInput = Input.GetAxis("Vertical");
        verticalInput = Input.GetAxis("Horizontal");

        headBone.Translate(horizontalInput * Time.deltaTime * speed * Vector3.right);
        headBone.Translate(verticalInput * Time.deltaTime * speed * Vector3.forward);
    }
}
