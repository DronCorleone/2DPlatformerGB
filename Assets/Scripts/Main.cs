using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    //[SerializeField]
    //private SpriteRenderer _back;
    //[SerializeField]
    //private SomeView _someView;
    //add links to test views <1>

    //private SomeManager _someManager;
    //add links to some logic managers <2>
    private CharacterView _character;
    private SpriteAnimator _animator;
    private SpriteAnimationsConfig _characterAnimationConfig;


    private void Start()
    {
        //SomeConfig config = Resources.Load("SomeConfig", typeof(SomeConfig))as   SomeConfig;
        //load some configs here <3>
        
        _characterAnimationConfig = Resources.Load<SpriteAnimationsConfig>(StringsManager.CharacterAnimationConfig);
        _character = FindObjectOfType<CharacterView>();
        _animator = new SpriteAnimator(_characterAnimationConfig);
        //_someManager = new SomeManager(config);
        //create some logic managers here for tests <4>
        _animator.StartAnimation(_character.SpriteRenderer, CharacterState.Idle, true, 10f);
    }

    private void Update()
    {
        //_someManager.Update();
        //update logic managers here <5>
    }

    private void FixedUpdate()
    {
        //_someManager.FixedUpdate();
        //update logic managers here <6>
        _animator.Update();
    }

    private void OnDestroy()
    {
        //_someManager.Dispose();
        //dispose logic managers here <7>
    }

}
