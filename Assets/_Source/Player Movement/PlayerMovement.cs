using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private bool isInputHold;

    private IInputHandler inputHandler;

    [Inject]
    private void Construct(IInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    private void FixedUpdate()
    {
        if (isInputHold)
        {
            MoveToSide();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
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
        if(touchPosition.x > Screen.width / 2)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if(touchPosition.x < Screen.width / 2)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
}
