using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    [SerializeField] int movementSpeed = 5;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Transform weaponsArm;

    private Vector2 movementInput;
    private Camera mainCamera;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        playerRigidbody.velocity = movementInput * movementSpeed;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerPosition = mainCamera.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mousePosition.x - playerPosition.x, mousePosition.y - playerPosition.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        //weaponsArm.rotation = Quaternion.Euler(0,0,angle);

        if(mousePosition.x < playerPosition.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

        if( movementInput != Vector2.zero)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);

        }


    }

    
}
