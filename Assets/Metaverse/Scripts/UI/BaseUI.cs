using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public abstract class BaseUI : MonoBehaviour
    {
        protected PlayerController player;
        protected UIManager uiManager;

        public virtual void Init(UIManager uiManager)
        {
            player = FindObjectOfType<PlayerController>();
            this.uiManager = uiManager;
        }

        protected abstract UIState GetUIState();
        public void SetActive(UIState state)
        {
            this.gameObject.SetActive(GetUIState() == state);
        }
    }
}