///Controller script created to help set up opponent movement and trigger state

using UnityEngine;
using UnityEngine.UI;

public class OpponentController : MonoBehaviour
{
    [SerializeField] private float _minSpeed, _maxSpeed, _rotationSpeed;
    [SerializeField] private Text _nameField;

    private float _moveSpeed;
    private Transform _playerObject;

    private GameController _gameController;

    private void Start()
    {
        _gameController = GameController.Instance;
        _playerObject = _gameController.PlayerObject.transform;
    }

    private void Update()
    {
        Vector3 playerDirection = _playerObject.position - transform.position;
        playerDirection.y = 0;

        if(playerDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }

        if(_gameController.PlayerMoved)
            MoveOpponent(playerDirection.normalized);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _gameController.EndGame(false);
    }

    /// <summary>
    /// Sets a randomized speed between minimum and maximum variables
    /// </summary>
    public void SetSpeed()
    {
        _moveSpeed = Random.Range(_minSpeed, _maxSpeed);
    }

    /// <summary>
    /// Sets a name picked by the opponent spawn controller based on the spawn position
    /// </summary>
    /// <param name="name"></param>
    public void SetName(string name)
    {
        _nameField.text = name;
    }

    /// <summary>
    /// Moves the opponent object towards the player
    /// </summary>
    /// <param name="direction"></param>
    private void MoveOpponent(Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
    }
}
