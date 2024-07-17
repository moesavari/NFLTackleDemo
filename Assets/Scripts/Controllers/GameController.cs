using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    [SerializeField] private Spawner _playerSpawner;
    public bool PlayerMoved = false;

    public GameObject PlayerObject { get; private set; }

    private PlayerController _playerController;

    private OpponentSpawnController _oppSpawnController;
    private CanvasController _canvasController;

    private void Start()
    {
        _oppSpawnController = OpponentSpawnController.Instance;
        _canvasController = CanvasController.Instance;

        InitializeGame();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ResetGame();
        }
    }

    public void EndGame(bool playerWon)
    {
        PlayerMoved = false;
        SetPlayerMovement(false);

        _canvasController.ShowEndScreen(playerWon ? CanvasController.EndScreen.WIN : CanvasController.EndScreen.LOSE);
    }

    public void InitializeGame()
    {
        PlayerObject = _playerSpawner.InstantiateObject();
        _playerController = PlayerObject.GetComponent<PlayerController>();

        _oppSpawnController.InstantiateOpponentObjects();
    }

    public void SetPlayerMovement(bool canMove)
    {
        _playerController.CanMove = canMove;
    }

    private void ResetGame()
    {
        PlayerMoved = false;
        SetPlayerMovement(false);

        _oppSpawnController.ResetSpwners();
        PlayerObject.transform.position = _playerSpawner.transform.position;
        PlayerObject.transform.rotation = _playerSpawner.transform.rotation;

        _canvasController.ShowWelcomeScreen();
    }
}
