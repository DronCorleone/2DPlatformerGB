using UnityEngine;


public class PauseMenu : BaseMenu
{
    [Header("Panel of pause menu")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _resumeButton;
    [SerializeField] private ButtonUI _exitButton;

    private UIController _uiController;

    private void Start()
    {
        _uiController = transform.parent.GetComponentInChildren<UIController>();

        _resumeButton.GetControl.onClick.AddListener(() => _uiController.StartGame());
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