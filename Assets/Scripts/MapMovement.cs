using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour {

    public AnimationCurve MovementCurve;

    Vector3 StartLocation;
    Vector3 TargetLocation;
    float timer = 0;
    bool inputActive = true;

    private bool facingRight;

    bool inputReady = true;

    bool startedTravelling = false;

    private void Awake()
    {
        GetComponent<Collider2D>().enabled = false;
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
        facingRight = transform.localScale.x == -1.0f ? true : false;
        if (inputActive && Input.GetMouseButtonUp(0))
        {
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
        }
        else if(inputActive && Input.touchCount > 0)
        {
            StartLocation = transform.position.ToVector3_2D();
            timer = 0;
            TargetLocation = WorldExtensions.GetScreenPositionFor2D(Input.GetTouch(0).position);
            startedTravelling = true;
        }

        if (TargetLocation!=Vector3.zero && TargetLocation!=transform.position && TargetLocation != StartLocation)
        {
            transform.position = Vector3.Lerp(StartLocation, TargetLocation, MovementCurve.Evaluate(timer));
            timer += Time.deltaTime;
        }
        if (startedTravelling && Vector3.Distance(StartLocation, transform.position.ToVector3_2D()) > 0.5)
        {
            GetComponent<Collider2D>().enabled = true;
            startedTravelling = false;
        }

        //if(!inputReady && inputActive)
        //{
        //    TargetLocation = this.transform.position;
        //    Debug.Log("Stopping player");
        //}

        inputActive = inputReady;
    }
}
