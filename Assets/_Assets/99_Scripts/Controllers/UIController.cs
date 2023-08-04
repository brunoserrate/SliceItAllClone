using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class UIController : MonoBehaviour {
        [Header("Panels")]
        [SerializeField] private GameObject _levelMessagePanel;
        [SerializeField] private GameObject _winMessagePanel;
        [SerializeField] private GameObject _loseMessagePanel;
        [SerializeField] private GameObject _inGameRestartButton;
        [SerializeField] private GameObject _tapToStartMessage;

        private void OnEnable() {
            GameStateController.OnGameStateChange += ChangeUIVisibility;
        }

        private void OnDisable() {
            GameStateController.OnGameStateChange -= ChangeUIVisibility;
        }

        private void ChangeUIVisibility(GameStates newGameState) {
            switch(newGameState) {
                case GameStates.Start:
                    _levelMessagePanel.SetActive(true);
                    _winMessagePanel.SetActive(false);
                    _loseMessagePanel.SetActive(false);
                    _inGameRestartButton.SetActive(false);
                    _tapToStartMessage.SetActive(true);
                    break;
                case GameStates.InGame:
                    _levelMessagePanel.SetActive(false);
                    _winMessagePanel.SetActive(false);
                    _loseMessagePanel.SetActive(false);
                    _inGameRestartButton.SetActive(true);
                    _tapToStartMessage.SetActive(false);
                    break;
                case GameStates.Win:
                    _levelMessagePanel.SetActive(false);
                    _winMessagePanel.SetActive(true);
                    _loseMessagePanel.SetActive(false);
                    _inGameRestartButton.SetActive(false);
                    _tapToStartMessage.SetActive(false);
                    break;
                case GameStates.Lose:
                    _levelMessagePanel.SetActive(false);
                    _winMessagePanel.SetActive(false);
                    _loseMessagePanel.SetActive(true);
                    _inGameRestartButton.SetActive(false);
                    _tapToStartMessage.SetActive(false);
                    break;
            }
        }

    }
}
