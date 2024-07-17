using UnityEngine;

public class OpponentController : MonoBehaviour
{
    [SerializeField] private float _minSpeed, _maxSpeed;

    private float _moveSpeed;
    private Transform _playerObject;

    private void Start()
    {
        _playerObject = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
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
