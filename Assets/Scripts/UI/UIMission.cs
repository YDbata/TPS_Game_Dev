using System.Collections.Generic;
using TPSGame.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPSGame.UI
{
    public class UIMission : UIPopUpBase
    {
        
        private IRepository<MissionDataModel> _repository;
        public List<MissionDataModel> missionDetail;
        
        void Awake()
        {
            base.Awake();
            _repository = GameManager.instance.unitOfWork.missionRepository;
            

            MissionSelect();
        }

        /// <summary>
        /// 미션4개를 난이도별로 랜덤하게 선택할 예정
        /// </summary>
        public void MissionSelect()
        {
            // 4개 선택 로직
            Debug.Log("UIMissionStart");
            _repository.GetAllItems();
            foreach (var missionData in _repository.GetAllItems())
            {
                missionDetail.Add(missionData);
            }
        }

        public void StartClick()
        {
            GameManager.instance.state = GameState.BattleLoaded;
            Cursor.visible = false;
        }
    }
}