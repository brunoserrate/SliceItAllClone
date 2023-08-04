using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class UIController : MonoBehaviour {
        [Header("Panels")]
        [SerializeField] private LevelDisplayUI _levelMessagePanel;
        [SerializeField] private GameObject _winMessagePanel;
        [SerializeField] private GameObject _loseMessagePanel;
        [SerializeField] private GameObject _inGameRestartButton;
        [SerializeField] private GameObject _tapToStartMessage;

        private void OnEnable() {
            GameStateController.OnGameStateChange += ChangeUIVisibility;
            LevelController.OnLevelLoaded += ActivateLevelMessagePanel;
        }

        // <summary>
        // Workaround to show the level message panel after the level is loaded.
        // This method is called from LevelController.OnLevelLoaded event, because the level message panel is disabled by default.
        // So it'll not hear the OnLevelLoaded event.
        // </summary>
        private void ActivateLevelMessagePanel(int levelIndex) {
            _levelMessagePanel.gameObject.SetActive(true);
            _levelMessagePanel.SetCurrentLevelIndex(levelIndex);
            _levelMessagePanel.SetLevelText();
        }

        private void OnDisable() {
            GameStateController.OnGameStateChange -= ChangeUIVisibility;
            LevelController.OnLevelLoaded -= ActivateLevelMessagePanel;
        }

        private void ChangeUIVisibility(GameStates newGameState) {
            switch(newGameState) {
                case GameStates.Start:
                    _levelMessagePanel.gameObject.SetActive(true);
                    _winMessagePanel.SetActive(false);
                    _loseMessagePanel.SetActive(false);
                    _inGameRestartButton.SetActive(false);
                    _tapToStartMessage.SetActive(true);
                    break;
                case GameStates.InGame:
                    _levelMessagePanel.gameObject.SetActive(false);
                    _winMessagePanel.SetActive(false);
                    _loseMessagePanel.SetActive(false);
                    _inGameRestartButton.SetActive(true);
                    _tapToStartMessage.SetActive(false);
                    break;
                case GameStates.Win:
                    _levelMessagePanel.gameObject.SetActive(false);
                    _winMessagePanel.SetActive(true);
                    _loseMessagePanel.SetActive(false);
                    _inGameRestartButton.SetActive(false);
                    _tapToStartMessage.SetActive(false);
                    break;
                case GameStates.Lose:
                    _levelMessagePanel.gameObject.SetActive(false);
                    _winMessagePanel.SetActive(false);
                    _loseMessagePanel.SetActive(true);
                    _inGameRestartButton.SetActive(false);
                    _tapToStartMessage.SetActive(false);
                    break;
            }
        }

    }
}
