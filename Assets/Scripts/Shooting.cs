using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static GameObject[] bColour = new GameObject[3];
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        
    }
}
