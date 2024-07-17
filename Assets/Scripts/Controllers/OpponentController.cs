///Controller script created to help set up opponent movement and trigger state

using UnityEngine;

public class OpponentController : MonoBehaviour
{
    [SerializeField] private float _minSpeed, _maxSpeed;

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
        if(_gameController.PlayerMoved)
            MoveOpponent(GetAngleOfPursuit());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
    /// Returns the position between the player and the opponent object
    /// </summary>
    /// <returns></returns>
    private Vector3 GetAngleOfPursuit()
    {
        return (_playerObject.position - transform.position).normalized;
    }

    /// <summary>
    /// Moves the opponent object towards the player
    /// </summary>
    /// <param name="direction"></param>
    private void MoveOpponent(Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.Self);
    }
}
