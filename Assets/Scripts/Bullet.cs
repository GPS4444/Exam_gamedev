using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("--- Bullet Orbit")]
    [SerializeField] float scale;
    [SerializeField] float speed;

    [Header("--- Shot")]
    [SerializeField] float shotSpeed;

    [Header("--- Colours")]
    [SerializeField] Color32 magenta = new Color32(255, 74, 164, 255);
    [SerializeField] Color32 blue = new Color32(74, 233, 255, 255);
    [SerializeField] Color32 green = new Color32(98, 255, 127, 255);

    private ParticleSystem particles;
    private GameObject player;
    private Material bMaterial;
    private float xPos;
    private float yPos;
    private int bName;

    void Start()
    {
        bName = BulletsManager.bCounter;
        player = GameObject.Find("Player");
        bMaterial = GetComponent<Renderer>().material;

        //particles = GetComponentInChildren<ParticleSystem>();
        //particles.Play();
    }

    void Update()
    {
        //orbit
        xPos = Mathf.Sin(Time.time * speed) * scale;
        yPos = Mathf.Sin(Time.time * speed * 2) * scale;

        transform.localPosition = new Vector3(xPos, yPos, 0);

        //check if colour has to change
        if (BulletsManager.bColourIndex == 0)
        {
            bMaterial.color = magenta;
        }
        else if (BulletsManager.bColourIndex == 1)
        {
            bMaterial.color = blue;                
        }
        else if (BulletsManager.bColourIndex == 2)
        {
            bMaterial.color = green;         
        }

        //change to shot state
        if (Input.GetMouseButtonDown(0) && bName == BulletsManager.bCounter)
        {
            BulletsManager.bCounter -= 1;

            Destroy(transform.parent.gameObject);
        }
    }

    
}



            //Old code

            // //curve, alligning bullet for actual shot
            // yPos = Mathf.Sin(shotTimer * shotSpeed) * shotCurveAmplitude;
            // xPos = Vector3.Lerp(, player.transform.position, shotTimer);
            // transform.localPosition = new Vector3(0, yPos, xPos);



            // if (isShot == false)
            // {
            //     //orbit
            //     xPos = Mathf.Sin(Time.time * speed) * scale;
            //     yPos = Mathf.Sin(Time.time * speed * 2) * scale;

            //     transform.localPosition = new Vector3(xPos, yPos, 0);

            //     //change to shot state
            //     if (Input.GetMouseButtonDown(0) && bName == BulletsManager.bCounter)
            //     {
            //         isShot = true;
            //         BulletsManager.bCounter -= 1;
            //         transform.position = player.transform.forward;

            //         //detach bullet gameobject from rig
            //         Transform bulletMesh = transform;
            //         Transform bulletRig = bulletMesh.parent;
            //         bulletMesh.SetParent(null);
            //         Destroy(bulletRig.gameObject);
                    
            //         //calculate shot direction                
            //         shotDirection = player.transform.forward;
            //         shotDirection = new Vector3 (shotDirection.x, 0, shotDirection.z);
            //     }
            // }
            //      else 
            // { 
            //     transform.Translate(shotSpeed * Time.deltaTime * shotDirection);
            // }