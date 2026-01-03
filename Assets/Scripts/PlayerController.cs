using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float highBoundPadding;
    [SerializeField] float lowBoundPadding;
    InputAction moveAction;
    Vector2 playerInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        playerInput = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + playerSpeed * Time.deltaTime * (Vector3)playerInput;

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + lowBoundPadding, maxBounds.y - highBoundPadding);

        transform.position = newPos;
    }
}
