

using System;
using System.Collections.Generic;

namespace TPSGame.Data
{
    /// <summary>
    /// 레파지토리 구현을 위한 인터페이스
    /// 삽입 삭제 수정 저장 전체불러오기 함수가 선언되어있다.
    /// </summary>
    /// <typeparam name="T"> 저장소에서 취급하는 데이터 형식 </typeparam>
    public interface IRepository<T>
    {
        event Action<int, T> onItemUpdated;

        IEnumerable<T> GetAllItems();

        T GetItemByID(int id);

        void InsertItem(T item);

        void DeleteItem(T item);

        void UpdateItem(int id, T item);

        void Save();
    }
}