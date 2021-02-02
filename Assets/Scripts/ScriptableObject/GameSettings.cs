using UnityEngine;


[CreateAssetMenu(fileName = "GameSettingsConfig", menuName = "Configs/Game settings config", order = 1)]
public class GameSettings : ScriptableObject
{
    [Header("Player movement")]
    [SerializeField] public float WalkSpeed;
    [SerializeField] public float JumpStartSpeed;
    [Range(-20f, 0f)] public float G;

    [Header("Player movement rigidbody")]
    [SerializeField] public float WalkSpeedRB;
    [SerializeField] public float JumpForse;

    [Header("Animation")]
    [SerializeField] public float AnimationSpeed;

    [Header("Cannon")]
    [SerializeField] public float BulletStartSpeed;
    [SerializeField] public float FireInterval;
}