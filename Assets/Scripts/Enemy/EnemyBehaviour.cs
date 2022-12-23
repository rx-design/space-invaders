using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip explosionClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Laser"))
        {
            return;
        }

        Destroy(gameObject);
        Destroy(collision.gameObject);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            return;
        }

        AudioSource.PlayClipAtPoint(explosionClip, transform.position);
        GameManager.Instance.SendMessage("OnEnemyDestroy");
    }
}
