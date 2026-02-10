using System.Collections;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    public static float maxBullets = 3;
    public static int bCounter = 0;
    public static int bColourIndex = 0;
    
    [SerializeField] GameObject bullet;
    [SerializeField] Material bMat;
    [SerializeField] float cdTime;
    
    private bool isOnCD = false;
    private float timeCounter;
    

    void Start()
    {
        SpawnBullet();
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

    public static void ChangeColourIndex(int x)
    {   
        bColourIndex += x;
        if (bColourIndex >= Shooting.bColour.Length)
        {
            bColourIndex -= Shooting.bColour.Length;
            ChangeColourIndex(0);
        }
    }
}