using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // generic constraint - generic kısıt
    // class : referans tip
    // where ile T yi filtreledik : class olmalı , ama bu class da IEntity ya da onu implemente eden nesnelerden olmalı yerine herhangi bir class yazılamamalı
    // new() : new lenebilir olmalı. yani soyut değil somut sınıflar kullanılabilmeli
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null); // listedeki Product entities de olduğu için ve onu kullandığımız için o katmanı referans aldık (Dependencies)
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
