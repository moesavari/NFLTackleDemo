///Controller script to assist with controlling the player conditions when certain colliders are hit

using UnityEngine;

public class FieldColliderController : MonoBehaviour
{
    public enum ColliderTypes
    {
        TOUCHDOWN,
        OUTOFBOUNDS,
    }

    public ColliderTypes ColliderType;

    private GameController _gameController;

    private void Start()
    {
        _gameController = GameController.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ColliderType == ColliderTypes.TOUCHDOWN)
                _gameController.EndGame(true);
            else if(ColliderType == ColliderTypes.OUTOFBOUNDS)
                _gameController.ShowOutOfBounds();
        }
    }
}
