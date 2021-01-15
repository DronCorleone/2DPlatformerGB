using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : IDisposable
{
    private SpriteAnimationsConfig _config;
    private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();

    public SpriteAnimator(SpriteAnimationsConfig config)
    {
        _config = config;
    }

    public void StartAnimation(SpriteRenderer spriteRenderer, CharacterState state, bool loop, float speed)
    {
        if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
        {
            animation.Loop = loop;
            animation.Speed = speed;
            animation.Sleeps = false;
            if (animation.State != state)
            {
                animation.State = state;
                animation.Sprites = _config.Sequences.Find(sequence => sequence.State == state).Sprites;
                animation.Counter = 0;
            }
        }
        else
        {
            _activeAnimations.Add(spriteRenderer, new Animation()
            {
                State = state,
                Sprites = _config.Sequences.Find(sequence => sequence.State == state).Sprites,
                Loop = loop,
                Speed = speed
            });
        }
    }

    public void StopAnimation(SpriteRenderer sprite)
    {
        if (_activeAnimations.ContainsKey(sprite))
        {
            _activeAnimations.Remove(sprite);
        }
    }

    public void Update()
    {
        foreach (var animation in _activeAnimations)
        {
            animation.Value.Update();
            animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
        }
    }

    public void Dispose()
    {
        _activeAnimations.Clear();
    }
}