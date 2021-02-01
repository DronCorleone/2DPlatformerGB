using UnityEngine;


public class MainMenu : BaseMenu
{
    [Header("Panel of main menu")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _startButton;
    [SerializeField] private ButtonUI _exitButton;

    private UIController _uiController;

    private void Start()
    {
        _uiController = transform.parent.GetComponent<UIController>();

        _startButton.GetControl.onClick.AddListener(() => _uiController.StartGame());
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
}