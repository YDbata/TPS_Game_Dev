using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TPSGame.UI
{
    public class UIPopUpBase : UIBase, IUIPopUp
    {
        // UI 바깥을 누르면 팝업이 닫힘
        [SerializeField] private bool _hideWhenPointerDownOutside;

        public override void InputAction(){
            base.InputAction();

            if (Input.GetMouseButtonDown(0))
            {
                if (UIManager.instance.TryCastOther(this, out IUI other, out GameObject hovered))
                {
                    if (other is IUIPopUp)
                    {
                        other.Show();
                    }
                }
            }else if (Input.GetMouseButtonDown(1))
            {
                // UI 나가기 구현
            }
        }
        
        public override void Show()
        {
            base.Show();
            UIManager.instance.Push(this);
        }
        
        public override void Hide()
        {
            base.Hide();
            UIManager.instance.Pop(this);
        }
        
        protected override void Awake()
        {
            base.Awake();

            if (_hideWhenPointerDownOutside)
                CreateOutsidePanel();
        }
        
        /// <summary>
        /// 바깥 마우스누름 이벤트를 감지하여 현재 팝업을 숨기는 패널 생성
        /// </summary>
        private void CreateOutsidePanel()
        {
            GameObject panel = new GameObject("Outside"); // 빈 게임오브젝트 생성
            panel.transform.SetParent(transform); // 현재 캔버스 하위에 게임오브젝트 종속
            panel.transform.SetAsFirstSibling(); // 맨 앞 자식으로 순서 재설정
            panel.AddComponent<Image>().color = new Color(0f, 0f, 0f, 0.4f); // 빈 게임오브젝트에 이미지 추가 후 색 설정.

            RectTransform rectTransform = (RectTransform)panel.transform; // UI 컴포넌트 추가되면 transform 은 RectTransform 으로 바뀜.
            rectTransform.anchorMin = Vector2.zero; // 앵커프리셋 앵커 최솟값 0,0 ( 앵커 프리셋 Stretch width-height )
            rectTransform.anchorMax = Vector2.one; // 앵커프리셋 앵커 최댓값 1,1 ( 앵커 프리셋 Stretch width-height )
            rectTransform.pivot = new Vector2(0.5f, 0.5f); // 앵커프리셋 피봇 0.5, 0.5 ( 앵커 프리셋 Stretch width-height )
            rectTransform.localScale = Vector3.one; // 스케일 1,1,1

            EventTrigger trigger = panel.AddComponent<EventTrigger>(); // 빈 게임오브젝트에 이벤트트리거 추가
            EventTrigger.Entry entry = new EventTrigger.Entry(); // 트리거 진입점 생성
            entry.eventID = EventTriggerType.PointerDown; // 트리거 진입 타입 설정 : 마우스 누름
            entry.callback.AddListener(eventData => Hide()); // 트리거 진입되었을때 팝업 숨김 콜백 등록
            trigger.triggers.Add(entry); // 생성한 트리거 진입점을 추가.
        }

    }
}