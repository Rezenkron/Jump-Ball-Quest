using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    private IInputHandler inputHandler;

    [Inject]
    private void Construct(IInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    private void Start()
    {
        inputHandler.GetInputHold(true);
        inputHandler.GetInputClick(true);
    }
}
