using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Service;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;


    private bool isInputHold;
    private bool isOnGround;

    private IInputHandler inputHandler;

    [Inject]
    private void Construct(IInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    private void DoJump()
    {
        if (isOnGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void FixedUpdate()
    { 
        DoJump();

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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.down, 1f, groundLayer);
        if(hit == true)
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (LayerChecker.CheckLayersEquality(collision.gameObject.layer, groundLayer))
        {
            isOnGround = false;
        }
    }
}
