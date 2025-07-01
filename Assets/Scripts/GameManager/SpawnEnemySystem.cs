using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySystem : MonoBehaviour
{

    [SerializeField] EnemySpawn enemySpawn;
    [SerializeField] private int waveNumber;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float countDown;
    [SerializeField] private float timeSpawnEnemy;
    [SerializeField] private float firstEnemyNumber;
    [SerializeField] List<GameObject> listEnemy;

    int countWave;
    void Start()
    {
        if (enemySpawn.enemy1 != null)
        {
            listEnemy.Add(enemySpawn.enemy1);

        }
        if (enemySpawn.enemy2 != null)
        {

            listEnemy.Add(enemySpawn.enemy2);
        }

    }
    // Update is called once per frame
    void Update()
    {
        // SpawnWave();
        if (countWave >= waveNumber) return;


        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            countWave++;
            SetupEnemy();
        }

        countDown -= Time.deltaTime;
    }

    void SetupEnemy()
    {
        if (countWave == (int)(waveNumber / 2))
        {
            if (enemySpawn.enemy3 != null)
            {
                listEnemy.Add(enemySpawn.enemy3);
            }
        }
        if (countWave >= waveNumber && enemySpawn.enemyBoss != null)
        {
            SpawnEnemy(enemySpawn.enemyBoss);
        }
        // if(countWave)
    }



    IEnumerator SpawnWave()
    {
        for (int i = 0; i < firstEnemyNumber; i++)
        {
            GameObject randomEnemy = listEnemy[Random.Range(0, listEnemy.Count)];
            SpawnEnemy(randomEnemy);
            yield return new WaitForSeconds(timeSpawnEnemy);
        }
        firstEnemyNumber += 2;
    }

    private void SpawnEnemy(GameObject _enemy)
    {
        List<Transform> randomPath = PathManager.instance.allPaths[Random.Range(0, PathManager.instance.allPaths.Count)];
        GameObject EnemyObj = ObjectPooling.Instance.GetObject(_enemy);
        EnemyObj.transform.SetParent(this.transform);
        EnemyObj.transform.position = new Vector2(randomPath[0].position.x + Random.Range(-3, 3), randomPath[0].position.y);
        EnemyObj.GetComponent<EnemyMovement>().SetPath(randomPath);
        EnemyObj.SetActive(true);
        GameManager.Instance.OnEnemySpawned(EnemyObj);
    }

    public bool IsEndWave()
    {
        return countWave >= waveNumber;
    }
}

[System.Serializable]

public class EnemySpawn
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemyBoss;


}
