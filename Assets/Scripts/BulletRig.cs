using UnityEngine;

public class BulletRig : MonoBehaviour
{
    void Start()
    {
        if (BulletsManager.bCounter % 2 == 0)
        {
            transform.localEulerAngles = new (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + (360 / (BulletsManager.maxBullets * 2) * BulletsManager.bCounter) + 180);
        }
        else
        {
            transform.localEulerAngles = new (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + (360 / (BulletsManager.maxBullets * 2) * BulletsManager.bCounter));
        }
    }

    void Update()
    {
        
    }
}
