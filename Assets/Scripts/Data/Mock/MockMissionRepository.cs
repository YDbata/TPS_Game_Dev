using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace TPSGame.Data.Mock
{
    public class MockMissionRepository : IRepository<MissionDataModel>
    {
        public MockMissionRepository()
        {
            _path = Application.dataPath + "/Mission.json";
            if (File.Exists(_path))
            {
                _missionDataModels =
                    JsonConvert.DeserializeObject<List<MissionDataModel>>(File.ReadAllText(_path));
            }
            else
            {
                _missionDataModels = new List<MissionDataModel>(DEFAULT_CAPACITY);
                for (int i = 0; i < DEFAULT_CAPACITY; i++)
                {
                    _missionDataModels.Add(new MissionDataModel(0, "", 0, "", "", 0));
                }
                File.WriteAllText(_path, JsonConvert.SerializeObject((_missionDataModels)));
            }
        }
        
        
        private readonly string _path;
        private const int DEFAULT_CAPACITY = 30;
        public event Action<int, MissionDataModel> onItemUpdated;
        private List<MissionDataModel> _missionDataModels;
        public IEnumerable<MissionDataModel> GetAllItems()
        {
            return _missionDataModels;
        }

        public MissionDataModel GetItemByID(int id)
        {
            return _missionDataModels[id];
        }

        public void InsertItem(MissionDataModel item)
        {
            _missionDataModels.Add(item);
            Save();
        }

        public void DeleteItem(MissionDataModel item)
        {
            _missionDataModels.Remove(item);
            Save();
        }

        public void UpdateItem(int id, MissionDataModel item)
        {
            _missionDataModels[id] = item;
            Save();
            onItemUpdated?.Invoke(id, item);
        }

        public void Save()
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(_missionDataModels));
        }
    }
}