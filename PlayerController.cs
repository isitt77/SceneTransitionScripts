using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;

    Vector2 moveInput;

    Rigidbody2D rb2d;

    public PlayerSpawnLocationSO playerSpawnLocation;

    Animator animator;

    bool isMoving;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SetPlayerSpawnPosition();

        SetPlayerFacingDirection();
    }


    void SetPlayerSpawnPosition()
    {
        transform.position = playerSpawnLocation.GetNewPlayerPosition();
    }

    void SetPlayerFacingDirection()
    {
        animator.SetFloat("X", playerSpawnLocation.GetNewPlayerDirection().x);
        animator.SetFloat("Y", playerSpawnLocation.GetNewPlayerDirection().y);
    }


    // Better for physics. Will manage movement.
    void FixedUpdate()
    {
        Walk();
        Animate();
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }


    void Walk()
    {
        float velocityX = moveInput.x * walkSpeed * Time.deltaTime * 50;
        float velocityY = moveInput.y * walkSpeed * Time.deltaTime * 50;

        rb2d.velocity = new Vector2(velocityX, velocityY);
    }


    void Animate()
    {
        bool moveMagnitude = Mathf.Abs(moveInput.magnitude) > Mathf.Epsilon;

        if (moveMagnitude)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            animator.SetFloat("X", moveInput.x);
            animator.SetFloat("Y", moveInput.y);
        }
        animator.SetBool("isMoving", isMoving);
    }



    void OnExamine(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Examining something");
        }
    }

}
