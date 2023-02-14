using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class ParameterRepository : EntityRepository<Parameter, SimRaDb>, IParameterRepository
    {
        public ParameterRepository(SimRaDb context) : base(context)
        {
        }
    }
}
