using MyFinance.Application.Contracts;
using MyFinance.Application.UseCases.Contracts;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Infra.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Application.UseCases
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task<User> Get(Expression<Func<User, bool>> predicate)
        {
            return await userRepository.Get(predicate);
        }

        public async Task<User> GetById(int id)
        {
            return await userRepository.GetById(id);
        }

        public async Task<IEnumerable<User>> GetEnumerable(Expression<Func<User, bool>> predicate)
        {
            return await userRepository.GetList(predicate);
        }

        public async Task Insert(User Object)
        {
            await userRepository.Insert(Object);
        }

        public async Task Remove(User Object)
        {
            await userRepository.Remove(Object);
        }

        public async Task Update(User Object)
        {
            await userRepository.Update(Object);
        }
    }
}
