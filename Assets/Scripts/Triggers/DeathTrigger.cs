using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DeathTrigger : MonoBehaviour
{
    private Main _main;

    private void Start()
    {
        _main = FindObjectOfType<Main>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterView>())
        {
            _main.EndGame(false);
        }
    }
}