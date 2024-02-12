using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    private int movementSpeed = 10;
    [SerializeField] Rigidbody2D playerRigidbody;

    private Vector2 movementInput;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        Utility.FacingDirection(transform,1f);
        Utility.PlayerState(movementInput, playerAnimator);
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = movementInput * movementSpeed;
    }

    void MovementInput()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput.Normalize();
    }


    
}
