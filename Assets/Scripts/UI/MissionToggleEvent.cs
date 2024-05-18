using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TPSGame.UI
{
    public class MissionToggleEvent : MonoBehaviour
    {
        [SerializeField]private ToggleGroup toggleGroup;
        [SerializeField]Toggle[] toggles;
        
        public void OnClick(Toggle actToggle)
        {
            // TODO : DB연동시 Mission 연결 필요
            if (actToggle.name[-1] == '1')
            {
                
            }  
        }
    }
}