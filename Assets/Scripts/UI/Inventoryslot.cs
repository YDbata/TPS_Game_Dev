using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

namespace TPSGame.UI
{
    public class Inventoryslot : MonoBehaviour
    {
        public int slotID { get; set; }
        public Sprite sprite => _has.sprite;
        [SerializeField] private GameObject _icon;
        [SerializeField] private Image _has;
        [SerializeField] private Sprite trueSprite;
        [SerializeField] private Sprite falseSprite;

        public void Refresh(int itemID, bool hasThis)
        {
            if (itemID > 0)
            {
                _icon = ItemInfoResources.instance[itemID].icon;
                _has.sprite = hasThis ? trueSprite : falseSprite;
            }
            else
            {
                _icon = null;
                _has.sprite = null;
            }
        }
    }
}