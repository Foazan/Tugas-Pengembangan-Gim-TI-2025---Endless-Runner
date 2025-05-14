using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemiesPrefabs;
    [SerializeField]
    private Transform _enemiesParent;
    public float enemySpawnTime = 2f;
    public float enemySpeed = 1f;
    private float _timeUntilEnemySpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.onGameOver.AddListener(ClearEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            Spawnloop();

        }
    }

    private void Spawnloop()
    {
        _timeUntilEnemySpawn += Time.deltaTime;

        if (_timeUntilEnemySpawn >= enemySpawnTime)
        {
            Spawn();
            _timeUntilEnemySpawn = 0f;
        }
    }

    private void ClearEnemies()
    {
        foreach (Transform child in _enemiesParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void Spawn()
    {
        Vector3 spawnPos = transform.position + Vector3.up * 0.2f;
        GameObject enemyToSpawn = _enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Length)];
        GameObject enemySpawned = Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        enemySpawned.transform.parent = _enemiesParent;
        Rigidbody2D enemyRB = enemySpawned.GetComponent<Rigidbody2D>();
        enemyRB.linearVelocity = Vector2.left * enemySpeed;
    }
}
