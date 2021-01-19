using UnityEngine;

public class PlayerMoveController
{
    private CharacterView _characterView;
    private SpriteAnimator _spriteAnimator;
    private GameSettings _settings;

    private Vector3 _leftScale = new Vector3(-1, 1, 1);
    private Vector3 _rightScale = new Vector3(1, 1, 1);
    
    private float xAxisInput = 0;
    private bool doJump = false;


    public PlayerMoveController (CharacterView characterView, SpriteAnimator spriteAnimator, GameSettings settings)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;
        _settings = settings;
    }

    public void Update()
    {
        doJump = Input.GetAxis(StringsManager.Vertical) > 0;
        xAxisInput = Input.GetAxis(StringsManager.Horizontal);
    }
}
