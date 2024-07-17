using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _mouseSensitivity;

    [SerializeField] private Camera _playerCamera;

    public bool CanMove = false;

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
        float horizontal = 0;
        float vertical = 0;

        if (Input.GetKey(KeyCode.W))
            vertical += 1;
        if (Input.GetKey(KeyCode.S))
            vertical -= 1;
        if (Input.GetKey(KeyCode.D))
            horizontal += 1;
        if (Input.GetKey(KeyCode.A))
            horizontal -= 1;

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * _moveSpeed * Time.deltaTime;

        if(movement != Vector3.zero)
            MovePlayer(movement);
    }

    private void MovePlayer(Vector3 movement)
    {
        GameController.Instance.PlayerMoved = true;

        transform.Translate(movement, Space.Self);
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
