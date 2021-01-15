using UnityEngine;
using System.Collections.Generic;
using System;


[CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/SpriteAnimationsConfig", order = 1)]
public class SpriteAnimationsConfig : ScriptableObject
{
    [Serializable]
    public class SpriteSequence
    {
        public CharacterState State;

        public List<Sprite> Sprites = new List<Sprite>();
    }

    [SerializeField] public List<SpriteSequence> Sequences;
}
