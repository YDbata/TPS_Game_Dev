using System;
using System.Collections.Generic;
using System.Linq;
using TPSGame.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TPSGame.UI
{
    public class InventoryUI : UIPopUpBase
    {
        [SerializeField] InventorySlot _slotPrefab; // 슬롯 데이터를 보여줄 기본 단위 원본
        [SerializeField] Transform _slotContent; // 슬롯 생성 위치
        private List<InventorySlot> _slots; // 생성된 슬롯들
        //[SerializeField] ItemController _itemControllerPrefab; // 슬롯의 아이템을 버릴때 월드에 생성할 컨트롤러
        private IRepository<InventorySlotDataModel> _repository; // 슬롯 데이터를 가지고있는 저장소
        private int _selectedSlotID = NOT_SELECTED;
        private const int NOT_SELECTED = -1;
        //[SerializeField] Image _selectedFollowingItemIcon;
        private List<RaycastResult> _results = new List<RaycastResult>();

        protected void Awake()
        {
            base.Awake();
            _repository = GameManager.instance.unitOfWork.inventoryRepository; // 저장소 주소 참조 받아옴 (의존성 주입)
            _slots = new List<InventorySlot>(_repository.GetAllItems().Count()); // 저장소에있는 데이터 갯수만큼 슬롯이 들어갈 자리 생성
            InventorySlot tmpSlot = null;
            int tmpSlotID = 0;
            
            //저장소(DB, Json) 순회 -> 슬롯 생성 및 갱신
            foreach(var slotData in _repository.GetAllItems())
            {
                
                tmpSlot = Instantiate(_slotPrefab, _slotContent);
                tmpSlot.SlotID = tmpSlotID++;
                Debug.Log(slotData.itemID+" "+slotData.hasThis);
                tmpSlot.Refresh(slotData.itemID, slotData.hasThis);
                _slots.Add(tmpSlot);
            }
        }
    }
}