using AuthServer.Core.Repositoryies;
using AuthServer.Core.Services;
using AuthServer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Servis.Services
{
    public class ServiceGeneric<T, TDTO> : IServiceGeneric<T, TDTO> where T : class where TDTO : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _genericRepository;
        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<TDTO>> AddAsync(TDTO entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<T>(entity);

            await _genericRepository.AddAsync(newEntity);

            await _unitOfWork.CommitAsync();

            var newDTO = ObjectMapper.Mapper.Map<TDTO>(newEntity);

            return Response<TDTO>.Success(newDTO, 200);
        }

        public async Task<Response<IEnumerable<TDTO>>> GetAllAsync()
        {
            var products = ObjectMapper.Mapper.Map<List<TDTO>>(await _genericRepository.GetAllAsync());

            return Response<IEnumerable<TDTO>>.Success(products, 200);
        }

        public async Task<Response<TDTO>> GetByIdAsync(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);

            if (product == null)
            {
                return Response<TDTO>.Fail("Id Not Found", 404, true);
            }

            var productDTO = ObjectMapper.Mapper.Map<TDTO>(product);
            return Response<TDTO>.Success(productDTO, 200);
        }

        public async Task<Response<NoDataDTO>> RemoveAsync(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return Response<NoDataDTO>.Fail("Id not found", 404, true);
            }

            _genericRepository.Remove(isExistEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDTO>.Success(204);
        }

        public async Task<Response<NoDataDTO>> UpdateAsync(TDTO entity, int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return Response<NoDataDTO>.Fail("Id not found", 404, true);
            }

            var updateEntity = ObjectMapper.Mapper.Map<T>(entity);
            _genericRepository.Update(updateEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDTO>.Success(204);
        }


        public async Task<Response<IEnumerable<TDTO>>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            var list = _genericRepository.Where(predicate);

            var listDTO = ObjectMapper.Mapper.Map<IEnumerable<TDTO>>(await list.ToListAsync());
            return Response<IEnumerable<TDTO>>.Success(listDTO, 200);
        }
    }
}
