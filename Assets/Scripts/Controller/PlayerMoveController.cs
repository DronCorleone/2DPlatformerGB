using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController
{
    private CharacterView _characterView;
    private SpriteAnimator _spriteAnimator;
    private float xAxisInput = 0;
    private bool doJump = false;

    private string _verticalAxis = "Vertical";
    private string _horizontalAxis = "Horizontal";

    public PlayerMoveController (CharacterView characterView, SpriteAnimator spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;
    }

    public void Update()
    {
        doJump = Input.GetAxis(_verticalAxis) > 0;
        xAxisInput = Input.GetAxis(_horizontalAxis);
    }
}
