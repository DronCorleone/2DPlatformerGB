using UnityEngine;


public class EndGameMenu : BaseMenu
{
    [Header("Panel of end game menu")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Text")]
    [SerializeField] private TextUI _textEndGame;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _retryButton;
    [SerializeField] private ButtonUI _exitButton;

    private UIController _uiController;

    private void Start()
    {
        _uiController = transform.parent.GetComponent<UIController>();

        _retryButton.GetControl.onClick.AddListener(() => _uiController.RestartGame());
        _exitButton.GetControl.onClick.AddListener(() => _uiController.ExitGame());
    }

    public override void Hide()
    {
        if (!IsShow) return;
        _mainPanel.gameObject.SetActive(false);
        IsShow = false;
    }

    public override void Show()
    {
        if (IsShow) return;
        _mainPanel.gameObject.SetActive(true);
        IsShow = true;
    }

    public void ActivateState(EndGameUIState state)
    {
        switch(state)
        {
            case EndGameUIState.Win:
                _textEndGame.GetControl.text = "Complete";
                _retryButton.gameObject.SetActive(false);
                break;
            case EndGameUIState.Lose:
                _textEndGame.GetControl.text = "Lose";
                break;
            case EndGameUIState.None:
                _textEndGame.GetControl.text = "None";
                break;

        }
    }
}