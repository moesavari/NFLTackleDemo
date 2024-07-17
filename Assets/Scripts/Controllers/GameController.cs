using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    [SerializeField] private Spawner _playerSpawner;
    public bool PlayerMoved = false;

    public GameObject PlayerObject { get; private set; }

    private OpponentSpawnController _oppSpawnController;

    private void Start()
    {
        _oppSpawnController = OpponentSpawnController.Instance;

        InitializeGame();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ResetGame();
        }
    }

    private void InitializeGame()
    {
        PlayerObject = _playerSpawner.InstantiateObject();
        _oppSpawnController.InstantiateOpponentObjects();
    }

    private void ResetGame()
    {
        PlayerMoved = false;

        _oppSpawnController.ResetSpwners();
        PlayerObject.transform.position = _playerSpawner.transform.position;
    }
}
