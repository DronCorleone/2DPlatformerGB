﻿using UnityEngine;


public class InGameUI : BaseMenu
{
    [Header("Panel of ingame UI")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _pauseButton;

    private UIController _uiController;

    private void Start()
    {
        _uiController = transform.parent.GetComponent<UIController>();

        _pauseButton.GetControl.onClick.AddListener(() => _uiController.PauseGame());
    }

    private void Update()
    {
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
