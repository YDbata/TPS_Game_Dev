using UnityEngine;
using UnityEngine.UIElements;

namespace TPSGame
{
    [CreateAssetMenu(fileName = "new ItemInfo", menuName = "ScriptableObjects/ItemInfo")]
    public class ItemInfo : ScriptableObject
    {
        [field: SerializeField] public int id { get; private set; }
        
        [field: SerializeField] public string description { get; private set; }
        [field: SerializeField] public string itemName { get; private set; }
        //[field: SerializeField] public int  { get; private set; }
        [field: SerializeField] public Sprite icon { get; private set; }
    }
}