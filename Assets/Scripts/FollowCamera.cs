using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public float xMargin = 1.5f;

    public float yMargin = 1.5f;

    public float xSmooth = 1.5f;

    public float ySmooth = 1.5f;

    private Vector2 maxXandY;

    private Vector2 minXandY;

    [SerializeField]
    private Transform player;

    private void Awake()
    {
        var backgroundBounds = GameObject.FindGameObjectWithTag("Background").GetComponent<Renderer>().bounds; //GameObject.Find("background01").GetComponent<Renderer>().bounds;
        var camera = GetComponent<Camera>();
        var camTopLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var camBottomRight = camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minXandY.x = backgroundBounds.min.x - camTopLeft.x;
        maxXandY.x = backgroundBounds.max.x - camBottomRight.x;
    }

    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    private void FixedUpdate()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }
        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
        targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
