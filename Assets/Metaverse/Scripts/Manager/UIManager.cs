using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public enum UIState
    {
        FlappyPlane,
        TheStack,
        TopDown
    }

    public class UIManager : MonoBehaviour
    {
        FlappyPlaneUI flappyPlaneUI;
        TheStackUI theStackUI;
        TopDownUI topDownUI;
        private UIState currentState;

        private void Awake()
        {
            flappyPlaneUI = GetComponentInChildren<FlappyPlaneUI>(true);
            flappyPlaneUI.Init(this);
            theStackUI = GetComponentInChildren<TheStackUI>(true);
            theStackUI.Init(this);
            topDownUI = GetComponentInChildren<TopDownUI>(true);
            topDownUI.Init(this);
        }

        public void ChangeState(UIState state)
        {
            currentState = state;
            flappyPlaneUI.SetActive(currentState);
            theStackUI.SetActive(currentState);
            topDownUI.SetActive(currentState);
        }
    }
}