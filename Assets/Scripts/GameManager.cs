using TMPro;
using UnityEditor.SearchService;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
    [SerializeField] int nEnemiesPerWave;
    [SerializeField] int enemyIncrement;
    [SerializeField] float speedIncrement;
    [SerializeField] float timePerWave;
    [SerializeField] float playerCDReduction;
    [SerializeField] float playerMinimumCD;
    
    [Header("--- Bounds")]
    public float mapSizeX;
    public float mapSizeZ;
    [SerializeField] float playerSafeZone;

    private int enemyIndex;
    private float timer;

    void Start()
    {
        timer = 0;
        enemiesDefeated = 0;
    }

    void Update()
    {
        txtScore.text = "ENEMIES DEFEATED: " + enemiesDefeated;

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     SpawnWave(nEnemiesPerWave);
        // }
        
        if (timer < timePerWave)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            SpawnWave(nEnemiesPerWave);
            EnemyBehaviour.speed += speedIncrement;
            BulletsManager.cdTime -= playerCDReduction;
            if (BulletsManager.cdTime < playerMinimumCD)
                BulletsManager.cdTime = playerMinimumCD;
            nEnemiesPerWave += enemyIncrement;   
        }
    }

        void SpawnWave(int n)
    {
        for (int i = 0; i <= n; i++)
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
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("Game");
    }
}