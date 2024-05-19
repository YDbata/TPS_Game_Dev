using System;
using UnityEngine;
using Newtonsoft.Json;

namespace TPSGame.Data
{
    public enum Grade
    {
        S,
        A,
        B,
        C,
        D,
        E,
        F
    }
    
    [Serializable]
    public class InventorySlotDataModel : IEquatable<InventorySlotDataModel>
    {
        [JsonConstructor]
        public InventorySlotDataModel(){
        }

        public InventorySlotDataModel(int itemID, bool hasThis, int itemGrade)
        {
            this.itemID = itemID;
            this.hasThis = hasThis;
            this.itemGrade = (Grade)itemGrade;
        }

        [JsonIgnore] public bool isEmpty => itemID == 0 ||  hasThis == false;

        public int itemID;
        public bool hasThis;
        public Grade itemGrade;

        public bool Equals(InventorySlotDataModel other)
        {
            return (this.itemID == other.itemID) && (this.hasThis == other.hasThis) && (this.itemGrade == other.itemGrade);
        }
    }
}

