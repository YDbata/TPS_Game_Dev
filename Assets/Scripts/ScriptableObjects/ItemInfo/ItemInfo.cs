using UnityEngine;

namespace TPSGame
{
    [CreateAssetMenu(fileName = "new ItemInfo", menuName = "ScriptableObjects/ItemInfo")]
    public class ItemInfo : ScriptableObject
    {
        [field: SerializeField] public int id { get; private set; }
        [field: SerializeField] public string description { get; private set; }
        //[field: SerializeField] public int  { get; private set; }
        [field: SerializeField] public GameObject icon { get; private set; }
    }
}