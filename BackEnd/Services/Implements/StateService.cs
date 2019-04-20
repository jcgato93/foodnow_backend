using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class StateService : GenericService<State>, IStateService
    {
        private IStateRepository stateRepository;

        public StateService(IStateRepository stateRepository)
             : base(stateRepository)
        {
            this.stateRepository = stateRepository;
        }
    }
}
