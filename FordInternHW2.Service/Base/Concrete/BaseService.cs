using AutoMapper;
using FordInternHW2.Base;
using FordInternHW2.Base.Response;
using FordInternHW2.Data.Repository.Abstract;
using FordInternHW2.Data.UnitOfWork.Abstract;
using FordInternHW2.Data.UnitOfWork.Concrete;
using FordInternHW2.Service.Base.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Service.Base.Concrete
{
    public abstract class BaseService<Dto, TEntity> : IBaseService<Dto, TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> genericRepository;
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<TEntity> genericRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.genericRepository = genericRepository;
        }

        public virtual async Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync()
        {
            var entityList = await genericRepository.GetAllAsync();
            var mapped = mapper.Map<IEnumerable<TEntity>, IEnumerable<Dto>>(entityList);
            return new BaseResponse<IEnumerable<Dto>>(mapped);
        }

        public virtual  async Task<BaseResponse<Dto>> GetByIdAsync(int id)
        {
            var entitySingle = await genericRepository.GetByIdAsync(id);
            var mapped = mapper.Map<TEntity, Dto>(entitySingle);
            return new BaseResponse<Dto>(mapped);
        }

        public virtual async Task<BaseResponse<bool>> PostAsync(Dto insertResource)
        {
            try
            {
                var entity = mapper.Map<Dto, TEntity>(insertResource);
                await genericRepository.PostAsync(entity);
                await unitOfWork.CompleteAsync();

                //return new BaseResponse<Dto>(mapper.Map<TEntity, Dto>(entity));
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "BaseService_Insert");
                return new BaseResponse<bool>(ex.StackTrace);
            };
        }

        public async Task<BaseResponse<bool>> Put(int id, Dto updateResource)
        {
            try
            {
                var entity = await genericRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    return new BaseResponse<bool>("No_Data");
                }

                var mappedEntity = mapper.Map<Dto, TEntity>(updateResource);
                mappedEntity.GetType().GetProperty("Id").SetValue(mappedEntity, id);

                genericRepository.Put(mappedEntity);
                await unitOfWork.CompleteAsync();

                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "BaseService_Update");
                return new BaseResponse<bool>(ex.StackTrace);
            }
        }

        public async Task<BaseResponse<bool>> Delete(int id)
        {
            try
            {
                var entity = await genericRepository.GetByIdAsync(id);
                if (entity is null)
                    return new BaseResponse<bool>("No_Data");

                genericRepository.Delete(entity);
                await unitOfWork.CompleteAsync();

                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "BaseService_Delete");
                return new BaseResponse<bool>(ex.StackTrace);
            }
        }

        public BaseResponse<List<Dto>> Where(Expression<Func<TEntity, bool>> where)
        {
            var entityList = genericRepository.Where(where).ToList();
            var mapped = mapper.Map<List<TEntity>, List<Dto>>(entityList);
            return new BaseResponse<List<Dto>>(mapped);
        }
    }
}
