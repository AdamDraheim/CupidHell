using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PowerUpSpawning : MonoBehaviour

{

    public GameObject enemyPrefab;

    public float spawnInterval = 8.0f;

    public float screenBoundX = 10.0f;

    public float screenBoundZ = 10.0f;



    // Start is called before the first frame update

    void Start()

    {

        StartCoroutine(powerUpWave());

    }



    private void spawnPowerUp()

    {

        GameObject enemy = Instantiate(enemyPrefab) as GameObject;



        float x = Random.Range(-screenBoundX, screenBoundX);

        float z = Random.Range(-screenBoundZ, screenBoundZ);



        enemy.transform.position = new Vector3(x, 10.0f, z);

    }



    IEnumerator powerUpWave()

    {

        while (true)

        {

            yield return new WaitForSeconds(spawnInterval);

            spawnPowerUp();

        }



    }



    // Update is called once per frame

    void Update()

    {



    }

}