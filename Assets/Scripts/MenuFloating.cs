using UnityEngine;

public class FloatingInMenu : MonoBehaviour
{
    [SerializeField] float floatingSpeed;
    [SerializeField] float floatingHeight;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direction = new (0, Mathf.Sin(Time.time * floatingSpeed) * floatingHeight, 0);

        transform.Translate(direction * Time.deltaTime, Space.World);
    }
}
