using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{

    [SerializeField] float arrowSpeed = 30f;
    private float distanceToLive = 0;
    private Rigidbody2D arrowRB;
    private Vector3 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        arrowRB = GetComponent<Rigidbody2D>();
        initPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        arrowRB.velocity = transform.right * arrowSpeed;



        float distanceMoved = Vector3.Distance(initPosition, transform.position);
        Debug.Log(distanceMoved);
        Debug.Log(distanceToLive);
        if(distanceMoved >= distanceToLive)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player" && collision.name != "Player Arrows") {
            Destroy(gameObject);
        }
    }

    public void SetDistanceToLive(float distance)
    {
        distanceToLive = distance;
    }


}
