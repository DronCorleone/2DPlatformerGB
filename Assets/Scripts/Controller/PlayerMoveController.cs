using UnityEngine;

public class PlayerMoveController
{
    private CharacterView _characterView;
    private SpriteAnimator _spriteAnimator;
    private GameSettings _settings;

    private Vector3 _leftScale = new Vector3(-1, 1, 1);
    private Vector3 _rightScale = new Vector3(1, 1, 1);

    private float _xAxisInput = 0;
    private float _yVelocity = 0;
    private float _movingThresh = 0.1f;
    private float _flyThresh = 1f;
    private float _groundLevel = 0.5f;
    private bool _doJump = false;
    private bool _doMove = false;


    public PlayerMoveController(CharacterView characterView, SpriteAnimator spriteAnimator, GameSettings settings)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;
        _settings = settings;
    }

    public void Update()
    {
        _doJump = Input.GetAxis(StringsManager.Vertical) > 0;
        _xAxisInput = Input.GetAxis(StringsManager.Horizontal);
        _doMove = Mathf.Abs(_xAxisInput) > _movingThresh;

        if (IsGrounded())
        {
            if (_doMove)
            {
                GoSideWay();
            }

            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, _doMove ? CharacterState.Run : CharacterState.Idle, true, _settings.AnimationSpeed);

            if (_doJump && _yVelocity == 0)
            {
                _groundLevel = _characterView.transform.position.y;
                _yVelocity = _settings.JumpStartSpeed;
            }
            else if (_yVelocity < 0)
            {
                _yVelocity = 0;
                _characterView.transform.position = _characterView.transform.position.Change(y: _groundLevel);
            }
        }
        else
        {
            if (_doMove)
            {
                GoSideWay();
            }

            if (Mathf.Abs(_yVelocity) > _flyThresh)
            {
                if (_yVelocity >= 0)
                {
                    _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, CharacterState.JumpUp, true, _settings.AnimationSpeed);
                }
                else
                {
                    _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, CharacterState.JumpDown, true, _settings.AnimationSpeed);
                }

            }
            _yVelocity += -10f * Time.fixedDeltaTime;
            _characterView.transform.position += Vector3.up * (Time.fixedDeltaTime * _yVelocity);
        }
    }

    private void GoSideWay()
    {
        _characterView.transform.position += Vector3.right * (Time.fixedDeltaTime * _settings.WalkSpeed * (_xAxisInput < 0 ? -1 : 1));
        _characterView.transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
    }

    public bool IsGrounded()
    {
        return _characterView.transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
    }
}