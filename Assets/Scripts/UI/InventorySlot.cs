using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

namespace TPSGame.UI
{
    public class InventorySlot : MonoBehaviour
    {
        public int SlotID { get; set; }
        [SerializeField] private GameObject _icon;
        [SerializeField] private Image _has;
        [SerializeField] private TMP_Text _name;
        private float noHasThis = 0.5f;
        public void Refresh(int itemID, bool hasThis)
        {
            Color tmpColor = _has.color;
            if (itemID > 0)
            {
                _icon = Instantiate(ItemInfoResources.instance[itemID].icon);
                _icon.transform.SetParent(this.gameObject.transform, false);
                tmpColor.a = hasThis ? 0f : noHasThis;
                _has.color = tmpColor;
                Debug.Log(ItemInfoResources.instance[itemID].itemName);
                _name.text = ItemInfoResources.instance[itemID].itemName;
            }
            else
            {
                _icon = null;
                tmpColor.a = noHasThis;
                _has.color = tmpColor;
                _name.text = string.Empty;
            }
        }
    }
}