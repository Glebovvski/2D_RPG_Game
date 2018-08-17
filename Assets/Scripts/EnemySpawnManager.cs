using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    public float spawnTime = 5f;

    public float spawnDelay = 3f;

    [SerializeField]
    private GameObject[] enemies;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
