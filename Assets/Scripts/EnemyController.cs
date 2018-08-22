using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private BattleManager battleManager;
    public Enemy EnemyProfile;
    Animator enemyAI;

    private bool selected;
    GameObject selectionCircle;

    private ParticleSystem bloodSplatterParticles;

    public BattleManager BattleManager
    {
        get { return battleManager; }
        set { battleManager = value; }
    }

    private void Awake()
    {
        bloodSplatterParticles = GetComponentInChildren<ParticleSystem>();
        if (bloodSplatterParticles == null)
        {
            Debug.LogError("No Particle System Found");
        }
        enemyAI = GetComponent<Animator>();
        if (enemyAI == null)
        {
            Debug.LogError("No AI System found");
        }
        enemyAI.SetInteger("EnemyHealth", 2);
    }

    private void Update()
    {
        UpdateAI();
    }

    public void UpdateAI()
    {
        if(enemyAI!=null && EnemyProfile != null)
        {
            enemyAI.SetInteger("EnemyHealth", EnemyProfile.Health);
            if (EnemyProfile.Health < 1)
                Destroy(GetComponent<BoxCollider2D>());
            enemyAI.SetInteger("PlayerHealth", GameState.CurrentPlayer.Health);
            enemyAI.SetInteger("EnemiesInBattle", battleManager.EnemyCount);
        }
    }

    void OnMouseDown()
    {
        if (battleManager.CanSelectEnemy)
        {
            var selection = !selected;
            battleManager.ClearSelectedEnemy();
            selected = selection;
            if (selected)
            {
                selectionCircle = (GameObject)GameObject.Instantiate(battleManager.selectionCircle);
                selectionCircle.transform.parent = transform;

                selectionCircle.transform.localPosition = new Vector3(0, -0.5f, 0);
                StartCoroutine("SpinObject", selectionCircle);
                battleManager.SelectEnemy(this, EnemyProfile.Name);
            }
        }
        
    }

    IEnumerator SpinObject(GameObject target)
    {
        while (true)
        {
            target.transform.Rotate(0, 0, 180 * Time.deltaTime);
            yield return null;
        }
    }

    public void ClearSelection()
    {
        if (selected)
        {
            selected = false;
            if (selectionCircle != null)
            {
                Destroy(selectionCircle);
                StopCoroutine("SpinObject");
            }
        }
    }

    void ShowBloodSplatter()
    {
        bloodSplatterParticles.Play();
        ClearSelection();
        if (battleManager != null)
        {
            battleManager.ClearSelectedEnemy();
        }
        else
        {
            Debug.LogError("No BattleManager");
        }
    }
}
