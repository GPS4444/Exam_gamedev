using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static int enemiesDefeated;

    [SerializeField] GameObject[] enemiesArray;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletManager;

    [Header ("--- UI")]
    [SerializeField] TextMeshProUGUI txtGameOver;
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] Volume globalVolume;

    [Header ("--- Wave")]
    [SerializeField] int nEnemiesStart;
    [SerializeField] int enemyIncrement;
    
    [Header("--- Bounds")]
    public float mapSizeX;
    public float mapSizeZ;
    [SerializeField] float playerSafeZone;

    private int enemyIndex;
    private int nEnemiesPerWave;
    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        txtScore.text = "ENEMIES DEFEATED: " + enemiesDefeated;


        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnWave(nEnemiesStart);
        }
    }

        void SpawnWave(int n)
    {
        for(int i = 0; i <= n; i++)
        {   
            enemyIndex = Random.Range(0, enemiesArray.Length);

            Instantiate(enemiesArray[enemyIndex], RandomizeSpawnLocation(), enemiesArray[enemyIndex].transform.rotation, transform);
        }
    }


    Vector3 RandomizeSpawnLocation()
    {
        Vector3 enemyPosition = new Vector3(Random.Range(-mapSizeX, mapSizeX), 0, Random.Range(-mapSizeZ, mapSizeZ));
        
        if ((enemyPosition.x < player.transform.position.x - playerSafeZone || enemyPosition.x > player.transform.position.x + playerSafeZone) && (enemyPosition.z < player.transform.position.z - playerSafeZone || enemyPosition.z > player.transform.position.z + playerSafeZone))
            return enemyPosition;
        else
            return RandomizeSpawnLocation();
    }

    public void GameOver()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        txtGameOver.gameObject.SetActive(true);
        //globalVolume.gameObject.SetActive
    }

    
}

    // public void GameStart()
    // {
    //     enemiesDefeated = 0;
    //     txtGameOver.gameObject.SetActive(false);
    //     player.GetComponent<CharacterControllerPlayer>().ResetPlayer();
    //     bulletManager.GetComponent<BulletsManager>().ResetBullets();
    // }