using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;

    private CircleCollider2D playerCollier;

    private bool isInputHold;
    private bool isOnGround;

    private IInputHandler inputHandler;

    [Inject]
    private void Construct(IInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    private void Start()
    {
        playerCollier = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        CheckGround();
        DoJump();
    }

    private void DoJump()
    {
        if (isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (isInputHold)
        {
            MoveToSide();
        }
        else
        {
            StopMoving();
        }
    }


    private void OnEnable()
    {
        inputHandler.OnInputHold += IsInputHold;
    }

    private void OnDisable()
    {
        inputHandler.OnInputHold -= IsInputHold;
    }

    private void IsInputHold(bool active)
    {
        isInputHold = active;
    }

    private void MoveToSide()
    {
        Vector3 touchPosition = Touchscreen.current.position.ReadValue();
        if (touchPosition.x > Screen.width / 2)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (touchPosition.x < Screen.width / 2)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - playerCollier.radius), -Vector2.up, 0.001f, groundLayer);

        if (hit == true)
        {
            isOnGround = true;
        } 
        else if(hit == false)
        { 
            isOnGround = false;
        }
    }
}
