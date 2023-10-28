using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputHandler();
    }

    private void BindInputHandler()
    {
        Container
            .Bind<IInputHandler>()
            .To<InputHandler>()
            .AsSingle()
            .NonLazy();
    }
}

public static class InjectIdData
{
}