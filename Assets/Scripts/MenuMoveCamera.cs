using NUnit.Framework;
using UnityEngine;

public class MenuMoveCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    [Header ("--- First Rotation")]
    [SerializeField] float speedDegrees1 = 20;
    [SerializeField] Vector3 pos1 = new Vector3 (0, 30.8f, -34.9f);
    [SerializeField] Vector3 rotation1 = new Vector3 (3, 0, 0);

    [Header ("--- Second Rotation")]
    [SerializeField] float speedDegrees2 = 20;
    [SerializeField] Vector3 pos2 = new Vector3 (17.2f, 38.2f, -32.7f);
    [SerializeField] Vector3 rotation2 = new Vector3 (4.44f, -27.74f, -32.7f);



    private float timer;
    private bool isDone;

    void Start()
    {
        transform.position = pos1;
        transform.eulerAngles = rotation1;
    }

    void Update()
    {  
        if(isDone == false)
        {
            if (timer < (360 / speedDegrees1))
            {
                transform.RotateAround(target.transform.position, Vector3.up, speedDegrees1 * Time.deltaTime);   
                timer += Time.deltaTime;
            }

            else if (isDone == false)
            {
                isDone = true;
                transform.position = pos2;
                transform.eulerAngles = rotation2;
                timer = 0;
            }
        }
        else
        {
            if (timer < (360 / speedDegrees2))
            {
                transform.RotateAround(target.transform.position, Vector3.down, speedDegrees2 * Time.deltaTime);
                timer += Time.deltaTime;
            }
            else
            {
                isDone = false;
                transform.position = pos1;
                transform.eulerAngles = rotation1;
                timer = 0;
            }
        }
    }
}
