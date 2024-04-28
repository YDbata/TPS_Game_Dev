using System.Collections.Generic;
using TPSGame.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TPSGame.UI
{
    public class InventoryUI : MonoBehaviour
    {
        /*[SerializeField] InventorySlot _slotPrefab; // 슬롯 데이터를 보여줄 기본 단위 원본
        [SerializeField] Transform _slotContent; // 슬롯 생성 위치
        private List<InventorySlot> _slots; // 생성된 슬롯들*/
        //[SerializeField] ItemController _itemControllerPrefab; // 슬롯의 아이템을 버릴때 월드에 생성할 컨트롤러
        private IRepository<InventorySlotDataModel> _repository; // 슬롯 데이터를 가지고있는 저장소
        private int _selectedSlotID = NOT_SELECTED;
        private const int NOT_SELECTED = -1;
        [SerializeField] Image _selectedFollowingItemIcon;
        private List<RaycastResult> _results = new List<RaycastResult>();
    }
}