using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class BaseService<RqDTO, TEntity, RsDTO> : IBaseService<RqDTO, TEntity, RsDTO>
		where TEntity : class
	{
		protected readonly IMapper _mapper;
		protected readonly AppDbContext _dbContext;
		protected readonly DbSet<TEntity> _dbSet;

		public BaseService(IMapper mapper, AppDbContext dbContext)
		{
			_mapper = mapper;
			_dbContext = dbContext;
			_dbSet = dbContext.Set<TEntity>();
		}

		public void Delete(int id)
		{
			var entiity = _dbSet.Find(id);
			_dbSet.Remove(entiity);
			_dbContext.SaveChanges();
		}

		public IEnumerable<RsDTO> GetAll()
		{
			var entity = _dbSet.ToList();
			var rsdto=_mapper.Map<IEnumerable<RsDTO>>(entity);
			return rsdto;
		}

		public RsDTO GetById(int id)
		{

			var entity = _dbSet.Find(id);
			var rsdto = _mapper.Map<RsDTO>(entity);
			return rsdto;
		}

		public RsDTO Insert(RqDTO dto)
		{
			var entity = _mapper.Map<TEntity>(dto);
			_dbSet.Add(entity);
			_dbContext.SaveChanges();
			var rsdto = _mapper.Map<RsDTO>(entity);
			return rsdto;
		}

		public void Update(RqDTO dto)
		{
			var entity = _mapper.Map<TEntity>(dto);
			_dbSet.Update(entity);
			_dbContext.SaveChanges();
		}
	}
}
