using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed;
    public float rotation;
    public Vector2 direction;

    private void Awake()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, rotation);
    }

    private void Update()
    {
        var translation = speed * Time.deltaTime * direction;

        transform.Translate(translation, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
