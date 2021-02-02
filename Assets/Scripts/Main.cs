using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private CharacterView _character;
    private CannonView _cannon;
    private List<BulletView> _bullets;

    private SpriteAnimator _animator;
    private PlayerMoveController _playerMoveController;
    private PlayerMoveControllerPhysics _playerMoveControllerPhysics;
    private CannonAimController _cannonAim;
    private BulletsEmitterController _bulletEmitterController;
    private CameraController _cameraController;
    private UIController _uiController;

    private SpriteAnimationsConfig _characterAnimationConfig;
    private GameSettings _gameSettingsConfig;


    private void Start()
    {   
        // Resources
        _characterAnimationConfig = Resources.Load<SpriteAnimationsConfig>(StringsManager.CharacterAnimationConfig);
        _gameSettingsConfig = Resources.Load<GameSettings>(StringsManager.GameSettingsConfig);

        // Objects on scene
        _character = FindObjectOfType<CharacterView>();
        _cannon = FindObjectOfType<CannonView>();
        _bullets = new List<BulletView>(FindObjectsOfType<BulletView>());

        // Controllers
        _animator = new SpriteAnimator(_characterAnimationConfig);
        //_playerMoveController = new PlayerMoveController(_character, _animator, _gameSettingsConfig);
        _playerMoveControllerPhysics = new PlayerMoveControllerPhysics(_character, _animator, _gameSettingsConfig);
        _cannonAim = new CannonAimController(_cannon.MuzzleTransform, _character.transform);
        _bulletEmitterController = new BulletsEmitterController(_bullets, _cannon.BulletTransform, _gameSettingsConfig);
        _cameraController = new CameraController(_camera, _character.gameObject);
        _uiController = FindObjectOfType<UIController>();

        _animator.StartAnimation(_character.SpriteRenderer, CharacterState.Idle, true, 10f);

        PauseGame();
    }

    private void Update()
    {
        _cannonAim.Update();
        _bulletEmitterController.Update();
        _animator.Update();
    }

    private void FixedUpdate()
    {
        //_playerMoveController.Update();
        _playerMoveControllerPhysics.FixedUpdate();
        _cameraController.FixedUpdate();
    }

    private void LateUpdate()
    {
    }

    private void OnDestroy()
    {
        //_someManager.Dispose();
        //dispose logic managers here <7>
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EndGame(bool isComplete)
    {
        Time.timeScale = 0;
        _uiController.EndGame(isComplete);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}