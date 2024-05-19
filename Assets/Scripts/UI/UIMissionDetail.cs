using System;
using TMPro;
using TPSGame.Data;
using UnityEngine;

namespace TPSGame.UI
{
    public class UIMissionDetail : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI MissionTitle;
        [SerializeField] private TextMeshProUGUI MissionContent;
        [SerializeField] private TextMeshProUGUI Location;
        [SerializeField] private TextMeshProUGUI EXP;

        private UIMission _uiMission;
        private MissionDataModel mission;
        
        public void Awake()
        {
            _uiMission = GetComponentInParent<UIMission>();
            TextWrite(1);
        }


        public void TextWrite(int missionNum)
        {

            mission = _uiMission.missionDetail[missionNum - 1];
            MissionTitle.text = mission.MissionTitle;
            MissionContent.text = mission.MissionContent;
            Location.text = "위치: " + mission.Location;
            EXP.text = "경험치: " + mission.EXP; }


    }
}