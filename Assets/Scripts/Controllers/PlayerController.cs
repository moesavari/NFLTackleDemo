/// Controller to assist with player movement and camera rotation

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _mouseSensitivity;

    [SerializeField] private Rigidbody _playerBody;

    [SerializeField] private Camera _playerCamera;

    public bool CanMove = false;

    private GameController _gameController;

    private void Start()
    {
        _gameController = GameController.Instance;
    }

    private void Update()
    {
        if(CanMove)
        {
            ProcessPlayerInput();
            RotateCamera();
        }
    }

    private void ProcessPlayerInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * _moveSpeed * Time.deltaTime;

        if (movement != Vector3.zero)
            MovePlayer(movement);
    }

    private void MovePlayer(Vector3 movement)
    {
        _gameController.PlayerMoved = true;

        // Calculate the camera's forward and right directions
        Vector3 camForward = _playerCamera.transform.forward;
        Vector3 camRight = _playerCamera.transform.right;

        // Flatten the camera's forward and right vectors to the XZ plane
        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * movement.z + camRight * movement.x;

        // Use Rigidbody to move the player, considering physics and collisions
        _playerBody.MovePosition(_playerBody.position + moveDirection);
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        _playerCamera.transform.Rotate(Vector3.left * mouseY);

        Vector3 camRotation = _playerCamera.transform.localEulerAngles;
        camRotation.x = Mathf.Clamp(camRotation.x, -45f, 45f);
        _playerCamera.transform.localEulerAngles = camRotation;
    }
}
