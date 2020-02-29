using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3.0f;
    public float screenBoundX = 10.0f;
    public float screenBoundZ = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyWave());
    }

    private void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab) as GameObject;

        float x = Random.Range(-screenBoundX * 1.5f, screenBoundX * 1.5f);
        float z;
        if (x > screenBoundX || x < -screenBoundX)
        {
            z = Random.Range(-screenBoundZ * 1.5f, screenBoundZ * 1.5f);
        } else
        {
            if (Random.Range(0.0f, 1.0f) > 0.4f)
            {
                z = Random.Range(-screenBoundZ * 1.5f, -screenBoundZ);
            }
            else
            {
                z = Random.Range(screenBoundZ, screenBoundZ * 1.5f);
            }
        }

        enemy.transform.position = new Vector3(x, 1.0f, z);
    }

    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            spawnEnemy();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
