using AutoMapper;
using CrossCutting.Logging;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class BaseService<TEntity, TEntityDTO> : IBaseService<TEntity, TEntityDTO>
        where TEntity : class, new()
        where TEntityDTO : class, new()
    {
        private readonly IMapper _mapper;

        Logger _log = null;
        protected IRepositoryBase _Repository = null;

        public BaseService(IRepositoryBase repository, IMapper mapper)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<TEntity, TEntityDTO>());

            //if (Mapper.Configuration.FindTypeMapFor(typeof(TEntity), typeof(TEntityDTO)) == null)
            //{
            //    Mapper.Initialize(cfg => cfg.CreateMap<TEntity, TEntityDTO>());
            //}

            _mapper = mapper;

            _log = new Logger();
            _Repository = repository;
        }

        public TEntityDTO Add(TEntity entity)
        {
            var unitOfWork = _Repository.UnitOfWork;
            TEntityDTO entityDTO = null;

            try
            {
                _Repository.Add(entity);
                unitOfWork.SaveChanges();
                entityDTO = _mapper.Map<TEntityDTO>(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return entityDTO;
        }

        public Task<TEntityDTO> AddAsync(TEntity entity)
        {
            return Task.Run(() => Add(entity));
        }

        public TEntityDTO Modify(TEntity entity)
        {
            var unitOfWork = _Repository.UnitOfWork;
            TEntityDTO entityDTO = null;

            try
            {
                _Repository.Modify(entity);
                unitOfWork.SaveChanges();
                entityDTO = _mapper.Map<TEntityDTO>(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return entityDTO;
        }

        public Task<TEntityDTO> ModifyAsync(TEntity entity)
        {
            return Task.Run(() => Modify(entity));
        }

        public int Modify(ICollection<TEntity> items)
        {
            var unitOfWork = _Repository.UnitOfWork;
            int result = 0;

            try
            {
                _Repository.Modify(items);
                result = unitOfWork.SaveChanges();

                //var x = Entry(item).State;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return result;
        }

        public Task<int> ModifyAsync(ICollection<TEntity> items)
        {
            return Task.Run(() => Modify(items));
        }

        public int Remove(params object[] keys)
        {
            var unitOfWork = _Repository.UnitOfWork;
            int result = 0;

            try
            {
                TEntity entity = _Repository.GetById<TEntity>(keys);

                _Repository.Remove(entity);
                result = unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return result;
        }

        public Task<int> RemoveAsync(params object[] keys)
        {
            return Task.Run(() => Remove(keys));
        }

        public TEntityDTO GetById(params object[] keys)
        {
            TEntityDTO entityDTO = null;

            try
            {
                TEntity entity = _Repository.GetById<TEntity>(keys);

                entityDTO = _mapper.Map<TEntityDTO>(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }
            return entityDTO;
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            IEnumerable<TEntityDTO> result = null;
            try
            {
                var list = _Repository.GetAll<TEntity>();

                result = _mapper.Map<IEnumerable<TEntityDTO>>(list);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }
            return result;
        }

        public IEnumerable<TEntityDTO> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntityDTO> result = null;
            try
            {
                var list = _Repository.FindBy(predicate);

                result = _mapper.Map<IEnumerable<TEntityDTO>>(list);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }
            return result;
        }
    }
}
