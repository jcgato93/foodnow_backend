using BackEnd.Models;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class StateService : GenericService<State>, IStateService
    {
        private StateRepository stateRepository;

        public StateService(StateRepository stateRepository)
             : base(stateRepository)
        {
            this.stateRepository = stateRepository;
        }
    }
}
