using UnityEngine;

namespace TPSGame.Data.Mock
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public MockUnitOfWork()
        {
            inventoryRepository = new MockInventoryRepository();
        }

        public bool isReady = true;
        
        public IRepository<InventorySlotDataModel> inventoryRepository { get; private set; }
    }
}