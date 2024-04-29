namespace TPSGame.Data.Mock
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public MockUnitOfWork()
        {
            inventoryRepository = new MockInventoryRepository();
        }

        // interfase 재정의
        public bool isReady => true;
        
        public IRepository<InventorySlotDataModel> inventoryRepository { get; private set; }
    }
}