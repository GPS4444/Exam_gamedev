using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    public static float maxBullets = 3;
    public static int bCounter = 0;
    public static int bColourIndex = 0;
    public static float cdTime = 2;

    [Header ("--- Shot Bullet")]
    [SerializeField] GameObject[] bColour;
    [SerializeField] Transform shootingManager;

    [Header ("--- Orbit Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] Material bMat;
    [SerializeField] float BulletCDTime = 2;

    
    private bool isOnCD = false;
    private float timeCounter;


    void Start()
    {
        isOnCD = false;
        timeCounter = 0;
        bCounter = 0;
        cdTime = BulletCDTime;
    }

    void Update()
    {
        //auto bullet supplying
        if (isOnCD == true && bCounter < maxBullets)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= cdTime)
            {
                isOnCD = false;
            }
        }
        else if(bCounter < maxBullets)
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        bCounter += 1;
        isOnCD = true;
        timeCounter = 0;

        Instantiate(bullet, transform);
    }

    public void ChangeColourIndex(int x)
    {   
        bColourIndex += x;
        bColourIndex %= bColour.Length;
    }

    public void ShotBullet()
    {
        Instantiate(bColour[bColourIndex], shootingManager);
    }

    // public void ResetBullets()
    // {
    //     isOnCD = false;
    //     timeCounter = 0;
    //     bCounter = 0;

    //     foreach (Transform child in this.transform)
    //     {
    //         Destroy(child.gameObject);
    //     }
    // }
}