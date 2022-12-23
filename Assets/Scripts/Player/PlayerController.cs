using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public float moveSpeed;
    public string inputName;

    private Camera _mainCamera;
    private float _rightLimit;
    private float _leftLimit;

    private void Start()
    {
        _mainCamera = Camera.main;

        if (!_mainCamera)
        {
            return;
        }

        var screenTopRightCorner = new Vector2(Screen.width, Screen.height);
        var topRightCornerInWorldSpace = _mainCamera.ScreenToWorldPoint(screenTopRightCorner);

        var screenBottomLeftCorner = new Vector2(0f, 0f);
        var bottomLeftCornerInWorldSpace = _mainCamera.ScreenToWorldPoint(screenBottomLeftCorner);

        var playerSpriteHalfWidth = playerSprite.bounds.size.x * 0.5f;

        _rightLimit = topRightCornerInWorldSpace.x - playerSpriteHalfWidth;
        _leftLimit = bottomLeftCornerInWorldSpace.x + playerSpriteHalfWidth;
    }

    private void Update()
    {
        var position = transform.position;

        switch (Input.GetAxis(inputName))
        {
            case > 0f when position.x < _rightLimit:
            {
                Move(position + new Vector3(1f, 0f, 0f));
                break;
            }
            case < 0f when position.x > _leftLimit:
            {
                Move(position - new Vector3(1f, 0f, 0f));
                break;
            }
        }
    }

    private void Move(Vector2 target)
    {
        var current = transform.position;
        var maxDistanceDelta = moveSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(current, target, maxDistanceDelta);
    }
}
