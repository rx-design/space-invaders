using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minPosX;
    public float maxPosX;
    public float moveDistance;
    public float timeStep;

    private bool _isMovingRight = true;

    private void Start()
    {
        InvokeRepeating(nameof(MoveEnemies), timeStep, timeStep);
    }

    private void MoveEnemies()
    {
        var position = transform.position;

        if (_isMovingRight)
        {
            var newPositionX = position.x + moveDistance;
            transform.position = new Vector2(newPositionX, position.y);

            if (newPositionX >= maxPosX)
            {
                _isMovingRight = false;
            }
        }
        else
        {
            var newPositionX = position.x - moveDistance;
            transform.position = new Vector2(newPositionX, position.y);

            if (newPositionX <= minPosX)
            {
                _isMovingRight = true;
            }
        }
    }
}
