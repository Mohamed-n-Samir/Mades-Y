using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{

    [SerializeField] float arrowSpeed = 5f;
    private Rigidbody2D arrowRB;

    // Start is called before the first frame update
    void Start()
    {
        arrowRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowRB.velocity = transform.right * arrowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "Player") {
            Destroy(gameObject);
        }
    }


}
