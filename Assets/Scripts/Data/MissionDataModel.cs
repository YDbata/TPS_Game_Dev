using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;

namespace TPSGame.Data
{
    [Serializable]
    public class MissionDataModel : IEquatable<MissionDataModel>
    {
        [JsonConstructor]
        public MissionDataModel()
        {
            
        }

        public MissionDataModel(int MissionID, String MissionTitle, int MissionGrade, String MissionContent, String Location, 
            int EXP)
        {
            this.MissionID = MissionID;
            this.Location = Location;
            this.MissionContent = MissionContent;
            this.MissionGrade = MissionGrade;
            this.MissionTitle = MissionTitle;
            this.EXP = EXP;
        }

        public int MissionID;
        public int MissionGrade;
        public String MissionContent;
        public String Location;
        public int EXP;
        public String MissionTitle;
        
        
        
        public bool Equals(MissionDataModel other)
        {
            return (this.MissionID == other.MissionID);
        }
        
    }
}