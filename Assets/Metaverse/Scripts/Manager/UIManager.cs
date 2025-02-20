using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public enum UIState
    {
        FlappyPlane,
        TheStack,
        TopDown,
        MyShield,
        RtanRain,
        FindRtan
    }

    public class UIManager : MonoBehaviour
    {
        FlappyPlaneUI flappyPlaneUI;
        TheStackUI theStackUI;
        TopDownUI topDownUI;
        MyShieldUI myShieldUI;
        RtanRainUI rtanRainUI;
        FindRtanUI findRtanUI;
        private UIState currentState;

        private void Awake()
        {
            flappyPlaneUI = GetComponentInChildren<FlappyPlaneUI>(true);
            flappyPlaneUI.Init(this);
            theStackUI = GetComponentInChildren<TheStackUI>(true);
            theStackUI.Init(this);
            topDownUI = GetComponentInChildren<TopDownUI>(true);
            topDownUI.Init(this);
            myShieldUI = GetComponentInChildren<MyShieldUI>(true);
            myShieldUI.Init(this);
            rtanRainUI = GetComponentInChildren<RtanRainUI>(true);
            rtanRainUI.Init(this);
            findRtanUI = GetComponentInChildren<FindRtanUI>(true);
            findRtanUI.Init(this);
        }

        public void ChangeState(UIState state)
        {
            currentState = state;
            flappyPlaneUI.SetActive(currentState);
            theStackUI.SetActive(currentState);
            topDownUI.SetActive(currentState);
            myShieldUI.SetActive(currentState);
            rtanRainUI.SetActive(currentState);
            findRtanUI.SetActive(currentState);
        }
    }
}