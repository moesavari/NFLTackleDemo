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

    public void SetSpeed()
    {
        _moveSpeed = Random.Range(_minSpeed, _maxSpeed);
    }

    private Vector3 GetAngleOfPursuit()
    {
        return (_playerObject.position - transform.position).normalized;
    }

    private void MoveOpponent(Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.Self);
    }
}
