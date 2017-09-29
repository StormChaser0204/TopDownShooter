using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyParent;
    public List<Transform> spawnPoints;

    private float spawnTime = 6;

    public void Start()
    {
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    public void Spawn()
    {
        Transform SpawnPos = GetPosition();
        Instantiate(enemyPrefab, SpawnPos.position, SpawnPos.rotation, enemyParent).GetComponent<EnemyBehaviour>().Spawn();
    }

    public Transform GetPosition()
    {
        Transform result;
        result = spawnPoints[Random.Range(0, spawnPoints.Count)];
        return result;
    }

    public void RespawnEnemy(GameObject enemy)
    {
        EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
        enemy.SetActive(true);
        enemyBehaviour.isActive = true;
        enemyBehaviour.speed = 3;
        enemy.transform.position = GetPosition().position;
        enemyBehaviour.Spawn();
    }
}
