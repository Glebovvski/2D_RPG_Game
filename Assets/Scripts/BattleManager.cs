using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public GameObject[] EnemySpawnPoints;

    public GameObject[] EnemyPrefabs;

    public AnimationCurve SpawnAnimationCurve;

    private int enemyCount;

    enum BattlePhase
    {
        PlayerAttack,
        EnemyAttack
    }

    private BattlePhase phase;

    private void OnGUI()
    {
        if(phase== BattlePhase.PlayerAttack)
        {
            if(GUI.Button(new Rect(10,10,100,50),"Run Away"))
            {
                GameState.PlayerReturningHome = true;
                NavigationManager.NavigateTo("World");
            }
        }
    }

    // Use this for initialization
    void Start () {
        enemyCount = Random.Range(1, EnemySpawnPoints.Length);
        StartCoroutine(SpawnEnemies());

        phase = BattlePhase.PlayerAttack;
	}
	
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var newEnemy = (GameObject)Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)]);

            newEnemy.transform.position = new Vector3(10, -1, 0);

            yield return StartCoroutine(MoveCharacterToPoint(EnemySpawnPoints[i], newEnemy));

            newEnemy.transform.parent = EnemySpawnPoints[i].transform;
        }
    }

    IEnumerator MoveCharacterToPoint(GameObject destination, GameObject character)
    {
        float timer = 0f;
        var startPosition = character.transform.position;

        if (SpawnAnimationCurve.length > 0)
        {
            while (timer < SpawnAnimationCurve.keys[SpawnAnimationCurve.length - 1].time)
            {
                character.transform.position = Vector3.Lerp(startPosition, destination.transform.position, SpawnAnimationCurve.Evaluate(timer));

                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            character.transform.position = destination.transform.position;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
