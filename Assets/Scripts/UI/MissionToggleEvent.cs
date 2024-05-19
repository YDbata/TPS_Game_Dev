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
        [SerializeField] private UIMissionDetail _missionDetail;

        public void OnClick(Toggle actToggle)
        {
            // TODO : DB연동시 Mission 연결 필요
            
            if (actToggle.name.Equals("Mission1"))
            {
                _missionDetail.TextWrite(1);
            }  else if (actToggle.name.Equals("Mission2"))
            {
                _missionDetail.TextWrite(2);
            }else if (actToggle.name.Equals("Mission3"))
            {
                _missionDetail.TextWrite(3);
            }else
            {
                _missionDetail.TextWrite(4);
            }
        }
    }
}