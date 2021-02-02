﻿using UnityEngine;

public class UIController : MonoBehaviour
{
    private MainMenu _mainMenu;
    private InGameUI _inGameUI;
    private PauseMenu _pauseMenu;
    private EndGameMenu _endGameMenu;

    private Main _mainController;

    private void Start()
    {
        _mainController = FindObjectOfType<Main>();

        _mainMenu = GetComponentInChildren<MainMenu>();
        _inGameUI = GetComponentInChildren<InGameUI>();
        _pauseMenu = GetComponentInChildren<PauseMenu>();
        _endGameMenu = GetComponentInChildren<EndGameMenu>();

        SwitchUI(UIState.MainMenu);
    }

    public void SwitchUI(UIState state)
    {
        switch (state)
        {
            case UIState.MainMenu:
                _mainMenu.Show();
                _inGameUI.Hide();
                _pauseMenu.Hide();
                _endGameMenu.Hide();
                break;
            case UIState.InGame:
                _mainMenu.Hide();
                _inGameUI.Show();
                _pauseMenu.Hide();
                _endGameMenu.Hide();
                break;
            case UIState.Pause:
                _mainMenu.Hide();
                _inGameUI.Hide();
                _pauseMenu.Show();
                _endGameMenu.Hide();
                break;
            case UIState.EndGame:
                _mainMenu.Hide();
                _inGameUI.Hide();
                _pauseMenu.Hide();
                _endGameMenu.Show();
                break;
        }
    }

    public void StartGame()
    {
        _mainController.StartGame();
        SwitchUI(UIState.InGame);
    }
    public void PauseGame()
    {
        _mainController.PauseGame();
        SwitchUI(UIState.Pause);
    }
    public void RestartGame()
    {
        _mainController.Retry();
    }
    public void EndGame(bool isLevelComplete)
    {
        SwitchUI(UIState.EndGame);

        if (isLevelComplete == true) _endGameMenu.ActivateState(EndGameUIState.Win);
        else _endGameMenu.ActivateState(EndGameUIState.Lose);
    }
    public void ExitGame()
    {
        _mainController.ExitGame();
    }
}