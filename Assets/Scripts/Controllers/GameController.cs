///Controller used to apply game rules and conditions. Can instantiate and reset game when needed

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
        Cursor.visible = true;
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

    /// <summary>
    /// Completes the game by disabling player movement and showing end screen
    /// playerWon bool helps by denoting which end screen to show
    /// </summary>
    /// <param name="playerWon"></param>
    public void EndGame(bool playerWon)
    {
        PlayerMoved = false;
        SetPlayerMovement(false);

        _canvasController.ShowEndScreen(playerWon ? CanvasController.EndScreen.WIN : CanvasController.EndScreen.LOSE);
    }

    public void ShowOutOfBounds()
    {
        PlayerMoved = false;
        SetPlayerMovement(false);

        _canvasController.ShowOutOfBoundsScreen();
    }

    public void InitializeGame()
    {
        PlayerObject = _playerSpawner.InstantiateObject();
        _playerController = PlayerObject.GetComponent<PlayerController>();

        _oppSpawnController.InstantiateOpponentObjects();
    }

    public void SetPlayerMovement(bool canMove)
    {
        //Toggling cursor visibility based on whether the player can move
        Cursor.visible = !canMove;
        _playerController.CanMove = canMove;
    }

    private void ResetGame()
    {
        _oppSpawnController.ResetSpwners();

        PlayerMoved = false;
        SetPlayerMovement(false);
        PlayerObject.transform.position = _playerSpawner.transform.position;
        PlayerObject.transform.rotation = _playerSpawner.transform.rotation;

        _canvasController.ShowWelcomeScreen();
    }
}
