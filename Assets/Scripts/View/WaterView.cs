using UnityEngine;

public class WaterView : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterView>())
        {
            FindObjectOfType<Main>().EndGame(false);
        }
    }
}