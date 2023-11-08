using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private AudioSource sceneMusic;
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