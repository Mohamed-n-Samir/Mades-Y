using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float chaseRange = 5f;
    private Rigidbody2D enemyRB;

    [SerializeField] float moveSpeed;
    [SerializeField] float chaseSpeed;
    private Vector3 chaseDirection;

    private Transform PlayerToChase;


    // Start is called before the first frame update
    void Start()
    {
        PlayerToChase = FindObjectOfType<PlayerMovment>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PlayerToChase.position, transform.position) <= chaseRange)
        {

        }
        else { 

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
