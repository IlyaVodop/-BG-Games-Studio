using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private Player _player;
    [SerializeField] private LabyrinthCreator _labyrinthCreator;
    public override void InstallBindings()
    {
        Container.BindInstances(_gameManager);
        Container.BindInstances(_uiManager);
        Container.BindInstances(_pauseMenu);
        Container.BindInstances(_player);
        Container.BindInstances(_labyrinthCreator);
    }
}