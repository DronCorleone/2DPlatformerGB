using System.Collections.Generic;
using UnityEngine;

public class Animation
{
    public CharacterState State;
    public List<Sprite> Sprites;
    public bool Loop = false;
    public float Speed = 10;
    public float Counter = 0;
    public bool Sleeps;

    public void Update()
    {
        if (Sleeps) return;
        Counter += Time.deltaTime * Speed;
        if (Loop)
        {
            while (Counter > Sprites.Count)
            {
                Counter -= Sprites.Count;
            }
        }
        else if (Counter > Sprites.Count)
        {
            Counter = Sprites.Count - 1;
            Sleeps = true;
        }
    }
}
