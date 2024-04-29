﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using TPSGame.Data;

namespace TPSGame.Data.Mock
{
    public class MockInventoryRepository : IRepository<InventorySlotDataModel>
    {
        public MockInventoryRepository()
        {
            _path = Application.dataPath + "/Inventory.json";
            //Assets/Inventory.json
            //Debug.Log(_path);
            if (File.Exists(_path))
            {
                _inventorySlotDataModels =
                    JsonConvert.DeserializeObject<List<InventorySlotDataModel>>(File.ReadAllText(_path));
            }
            else
            {
                _inventorySlotDataModels = new List<InventorySlotDataModel>(DEFAULT_CAPACITY);
                for (int i = 0; i < DEFAULT_CAPACITY; i++)
                {
                    _inventorySlotDataModels.Add(new InventorySlotDataModel(0, false, -1));
                }
                File.WriteAllText(_path, JsonConvert.SerializeObject(_inventorySlotDataModels));
            }
        }

        private readonly string _path;
        private const int DEFAULT_CAPACITY = 30;
        private List<InventorySlotDataModel> _inventorySlotDataModels;

        public event Action<int, InventorySlotDataModel> onItemUpdated;

        public IEnumerable<InventorySlotDataModel> GetAllItems()
        {
            return _inventorySlotDataModels;
        }

        public IEnumerable<InventorySlotDataModel> GetGradeItems(int itemGrade)
        {
            return _inventorySlotDataModels.FindAll(n => n.itemGrade == (Grade)itemGrade);
        }
        
        public InventorySlotDataModel GetItemByID(int id)
        {
            return _inventorySlotDataModels[id];
        }

        public void InsertItem(InventorySlotDataModel item)
        {
            _inventorySlotDataModels.Add(item);
            Save();
        }

        public void DeleteItem(InventorySlotDataModel item)
        {
            _inventorySlotDataModels.Remove(item);
            Save();
        }

        public void UpdateItem(int id, InventorySlotDataModel item)
        {
            _inventorySlotDataModels[id] = item;
            Save();
            onItemUpdated?.Invoke(id, item);
        }

        public void Save()
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(_inventorySlotDataModels));
        }
    }
}