///Controller script to assist with toggling canvas visibility

using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoSingleton<CanvasController>
{
    public enum EndScreen
    {
        LOSE,
        WIN,
    }

    [SerializeField] private GameObject _welcomeScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    [SerializeField] private Button _playButton;

    private GameController _gameController;

    private void Start()
    {
        _gameController = GameController.Instance;
        _playButton.onClick.AddListener(HideWelcomeScreen);

        ShowWelcomeScreen();
    }

    /// <summary>
    /// Shows the win or lose screen based on what enum is passed in
    /// </summary>
    /// <param name="endScreen"></param>
    public void ShowEndScreen(EndScreen endScreen)
    {
        switch(endScreen)
        {
            case EndScreen.LOSE:
                _loseScreen.SetActive(true);
                break;
            case EndScreen.WIN:
                _winScreen.SetActive(true);
                break;
        }
    }

    public void ShowWelcomeScreen()
    {
        _winScreen.SetActive(false);
        _loseScreen.SetActive(false);

        _welcomeScreen.SetActive(true);
    }

    public void HideWelcomeScreen()
    {
        _welcomeScreen.SetActive(false);
        _gameController.SetPlayerMovement(true);
    }
}
