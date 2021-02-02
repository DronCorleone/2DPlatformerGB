using UnityEngine;

public class PlayerMoveControllerPhysics
{
    private CharacterView _characterView;
    private SpriteAnimator _spriteAnimator;
    private GameSettings _settings;
    private ContactsPoller _contactsPoller;

    private Rigidbody2D _characterRigidbody;

    private float _jumpThresh = 0.1f;
    private float _flyThresh = 1f;
    private float _movingThresh = 0.1f;

    private float _goSideWay = 0;
    private bool _doJump = false;

    public PlayerMoveControllerPhysics(CharacterView view, SpriteAnimator spriteAnimator, GameSettings settings)
    {
        _characterView = view;
        _spriteAnimator = spriteAnimator;
        _contactsPoller = new ContactsPoller(_characterView.GetComponent<Collider2D>());
        _settings = settings;
        _characterRigidbody = _characterView.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        _doJump = Input.GetAxis(StringsManager.Vertical) > 0;
        _goSideWay = Input.GetAxis(StringsManager.Horizontal);
        _contactsPoller.Update();

        var walks = Mathf.Abs(_goSideWay) > _movingThresh;

        if (walks) _characterView.SpriteRenderer.flipX = _goSideWay < 0;

        var newVelocity = 0f;

        if (walks && (_goSideWay > 0 || !_contactsPoller.HasLeftContacts) && (_goSideWay < 0 || !_contactsPoller.HasRightContacts))
        {
            newVelocity = Time.fixedDeltaTime * _settings.WalkSpeedRB * (_goSideWay < 0 ? -1 : 1);
        }

        _characterRigidbody.velocity = _characterRigidbody.velocity.Change(x: newVelocity);

        if (_contactsPoller.IsGrounded && _doJump && Mathf.Abs(_characterRigidbody.velocity.y) <= _jumpThresh)
        {
            _characterRigidbody.AddForce(Vector3.up * _settings.JumpForse);
        }

        // Animations
        if (_contactsPoller.IsGrounded)
        {
            var track = walks ? CharacterState.Run : CharacterState.Idle;
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, track, true, _settings.AnimationSpeed);
        }
        else if (Mathf.Abs(_characterRigidbody.velocity.y) > _flyThresh)
        {
            CharacterState state = CharacterState.Idle;

            if (_characterRigidbody.velocity.y > 0)
            {
                state = CharacterState.JumpUp;
            }
            if (_characterRigidbody.velocity.y < 0)
            {
                state = CharacterState.JumpDown;
            }

            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, state, true, _settings.AnimationSpeed);
        }
    }
}