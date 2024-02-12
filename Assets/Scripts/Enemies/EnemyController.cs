using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float chaseRange = 5f;
    [SerializeField] float keepChasingRange = 8f;
    private Rigidbody2D enemyRB;

    [SerializeField] float moveSpeed;
    [SerializeField] float chaseSpeed;
    private Vector3 chaseDirection;

    private Transform PlayerToChase;
    private bool isChasing = false;
    [SerializeField] int enemyHealth = 100;

    private Animator enemyAnimator;


    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        PlayerToChase = FindObjectOfType<PlayerMovment>().transform;
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PlayerToChase.position, transform.position) <= chaseRange && !enemyAnimator.GetBool("die"))
        {
            chaseDirection = PlayerToChase.position - transform.position;
            isChasing = true;
            Utility.EnemyFacingDirection(transform, PlayerToChase, 1f);
        }
        else if ((Vector3.Distance(PlayerToChase.position, transform.position) <= keepChasingRange) && isChasing && !enemyAnimator.GetBool("die")) {
            chaseDirection = PlayerToChase.position - transform.position;
            Utility.EnemyFacingDirection(transform, PlayerToChase, 1f);
        }
        else {
            chaseDirection = Vector3.zero;
            isChasing = false;
        }



        chaseDirection.Normalize();
        enemyRB.velocity = chaseDirection * chaseSpeed;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if(enemyHealth < 0)
        {
            enemyAnimator.SetBool("die", true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, keepChasingRange);
    }

    private void EnemyDistroy()
    {
        Destroy(gameObject);
    }

}
