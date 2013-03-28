namespace InsuranceBroker.Services.EntityServices
{
    using System;
    using System.Collections.Generic;

    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> GetList();

        TEntity GetById(Guid id);

        TEntity Add(TEntity entity);

        void Delete(Guid id);

        TEntity Update(TEntity entity);
    }
}
