using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesArray;
    [SerializeField] Transform center;
    [SerializeField] int nEnemies;
    
    [Header("--- Bounds")]
    //[SerializeField] float mapSizeX;
    //[SerializeField] float mapSizeZ;
    [SerializeField] float innerSpawnBound;
    [SerializeField] float outerSpawnBound;


    void SpawnWave(int n)
    {
        for(int i = 0; i <= n; i++)
        {
            Instantiate(enemiesArray[0], new Vector3 (Random.Range(innerSpawnBound, outerSpawnBound), 0, Random.Range(innerSpawnBound, outerSpawnBound)), enemiesArray[0].transform.rotation);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnWave(nEnemies);
        }
    }
}
