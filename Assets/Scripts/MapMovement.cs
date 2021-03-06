﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMovement : MonoBehaviour {

    public AnimationCurve MovementCurve;
    private Animator anim;

    Vector3 StartLocation;
    Vector3 TargetLocation;
    float timer = 0;
    bool inputActive = true;

    int encounterChance = 100;
    float encounterDistance = 0;

    private bool facingRight;

    bool inputReady = true;

    bool startedTravelling = false;

    private void Awake()
    {
        GetComponent<Collider2D>().enabled = false;
        anim = GetComponent<Animator>();

        var lastPosition = GameState.GetLastScenePosition(SceneManager.GetActiveScene().name);

        if (lastPosition != Vector3.zero)
            transform.position = lastPosition;
    }

    private void Start()
    {
        //MessagingManager.Instance.SubscribeUIEvent(UpdateInputAction);
    }

    private void UpdateInputAction(bool uiVisible)
    {
        //inputReady = !uiVisible;
    }

    private void Update()
    {
        if (TargetLocation != Vector3.zero && TargetLocation != transform.position && TargetLocation != StartLocation)
        {
            transform.position = Vector3.Lerp(StartLocation, TargetLocation, MovementCurve.Evaluate(timer));
            timer += Time.deltaTime;
        }
        if (startedTravelling && Vector3.Distance(StartLocation, transform.position.ToVector3_2D()) > 0.5)
        {
            GetComponent<Collider2D>().enabled = true;
            startedTravelling = false;
            anim.SetFloat("speed", 0f);
        }

        if (encounterDistance > 0)
        {
            if (Vector3.Distance(StartLocation, transform.position) > encounterDistance)
            {
                TargetLocation = Vector3.zero;
                NavigationManager.NavigateTo("Battle");
            }
        }
    }

    private void FixedUpdate()
    {
        facingRight = transform.localScale.x == -1.0f ? true : false;
        if (inputActive && Input.GetMouseButtonUp(0))
        {
            float movePlayerVector = Input.mousePosition.GetScreenPositionFor2D().x;

            anim.SetFloat("speed", Mathf.Abs(movePlayerVector));
            Vector2 posMouse = Input.mousePosition.GetScreenPositionFor2D();
            if (posMouse.x < transform.position.x && facingRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            else if (posMouse.x > transform.position.x && !facingRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            StartLocation = transform.position.ToVector3_2D();
            timer = 0;
            TargetLocation = WorldExtensions.GetScreenPositionFor2D(Input.mousePosition);
            startedTravelling = true;

            var encounterProbability = Random.Range(1, 100);
            if (encounterProbability < encounterChance && !GameState.PlayerReturningHome)
            {
                encounterDistance = (Vector3.Distance(StartLocation, TargetLocation) / 100) * Random.Range(10, 100);
            }
            else encounterDistance = 0;
        }
        else if(inputActive && Input.touchCount > 0)
        {
            StartLocation = transform.position.ToVector3_2D();
            timer = 0;
            TargetLocation = WorldExtensions.GetScreenPositionFor2D(Input.GetTouch(0).position);
            startedTravelling = true;
        }

        

        //if(!inputReady && inputActive)
        //{
        //    TargetLocation = this.transform.position;
        //    Debug.Log("Stopping player");
        //}

        inputActive = inputReady;
    }

    private void OnDestroy()
    {
        GameState.SetLastScenePosition(SceneManager.GetActiveScene().name, transform.position);
    }
}
