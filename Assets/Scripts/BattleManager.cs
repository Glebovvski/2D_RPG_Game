using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public GameObject[] EnemySpawnPoints;

    public GameObject[] EnemyPrefabs;

    public AnimationCurve SpawnAnimationCurve;

    private int enemyCount;

    private Animator battleStateManager;

    private InventoryItem selectedWeapon;

    private Dictionary<int, BattleState> battleStateHash = new Dictionary<int, BattleState>();
    private BattleState currentBattleState;

    public enum BattleState
    {
        Begin_Battle,
        Intro,
        Player_Move,
        Player_Attack,
        Change_Control,
        Enemy_Attack,
        Battle_Result,
        Battle_End
    }

    private void InventoryItemSelect(InventoryItem item)
    {
        selectedWeapon = item;
    }

    void GetAnimationStates()
    {
        foreach (BattleState state in (BattleState[])Enum.GetValues(typeof(BattleState)))
        {
            battleStateHash.Add(Animator.StringToHash("Base Layer." + state.ToString()), state);
        }
    }

    private void OnGUI()
    {
        switch (currentBattleState)
        {
            case BattleState.Begin_Battle:
                break;
            case BattleState.Intro:
                GUI.Box(new Rect((Screen.width / 2) - 150, 50, 300, 50), "Battle between Player and Goblins");
                break;
            case BattleState.Player_Move:
                if (GUI.Button(new Rect(10,10,100,50),"Run Away"))
                {
                    GameState.PlayerReturningHome = true;
                    NavigationManager.NavigateTo("World");
                }
                if (selectedWeapon == null)
                {
                    GUI.Box(new Rect((Screen.width / 2) - 50, 10, 100, 50), "Select Weapon");
                }
                break;
            case BattleState.Player_Attack:
                break;
            case BattleState.Change_Control:
                break;
            case BattleState.Enemy_Attack:
                break;
            case BattleState.Battle_Result:
                break;
            case BattleState.Battle_End:
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start () {
        enemyCount = UnityEngine.Random.Range(1, EnemySpawnPoints.Length);
        StartCoroutine(SpawnEnemies());
        battleStateManager = GetComponent<Animator>();
        GetAnimationStates();
        MessagingManager.Instance.SubscribeInventoryEvent(InventoryItemSelect);
	}
	
    void Update()
    {
        currentBattleState = battleStateHash[battleStateManager.GetCurrentAnimatorStateInfo(0).fullPathHash];
        switch (currentBattleState)
        {
            case BattleState.Begin_Battle:
                break;
            case BattleState.Intro:
                break;
            case BattleState.Player_Move:
                break;
            case BattleState.Player_Attack:
                break;
            case BattleState.Change_Control:
                break;
            case BattleState.Enemy_Attack:
                break;
            case BattleState.Battle_Result:
                break;
            case BattleState.Battle_End:
                break;
            default:
                break;
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var newEnemy = (GameObject)Instantiate(EnemyPrefabs[UnityEngine.Random.Range(0, EnemyPrefabs.Length)]);
            newEnemy.GetComponent<Rigidbody2D>().freezeRotation = true;
            newEnemy.transform.position = new Vector3(10, -1, 0);

            yield return StartCoroutine(MoveCharacterToPoint(EnemySpawnPoints[i], newEnemy));

            newEnemy.transform.parent = EnemySpawnPoints[i].transform;
        }
        battleStateManager.SetBool("BattleReady", true);
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
}
