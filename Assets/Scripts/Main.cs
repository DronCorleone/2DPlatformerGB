using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private CharacterView _character;
    private SpriteAnimator _animator;
    private SpriteAnimationsConfig _characterAnimationConfig;
    private GameSettings _gameSettingsConfig;
    private PlayerMoveController _playerMoveController;


    private void Start()
    {   
        _characterAnimationConfig = Resources.Load<SpriteAnimationsConfig>(StringsManager.CharacterAnimationConfig);
        _gameSettingsConfig = Resources.Load<GameSettings>(StringsManager.GameSettingsConfig);

        _character = FindObjectOfType<CharacterView>();

        _animator = new SpriteAnimator(_characterAnimationConfig);
        _playerMoveController = new PlayerMoveController(_character, _animator, _gameSettingsConfig);

        _animator.StartAnimation(_character.SpriteRenderer, CharacterState.Idle, true, 10f);
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        _animator.Update();
        _playerMoveController.Update();
    }

    private void OnDestroy()
    {
        //_someManager.Dispose();
        //dispose logic managers here <7>
    }

}
