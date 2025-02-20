using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Metaverse
{
    public class MyShieldUI : BaseUI
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            startButton.onClick.AddListener(OnClickStartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        public void OnClickStartButton()
        {
            SceneManager.LoadScene(4);
        }

        public void OnClickExitButton()
        {
            this.gameObject.SetActive(false);
            player.isStop = false;
        }

        protected override UIState GetUIState()
        {
            return UIState.MyShield;
        }
    }
}