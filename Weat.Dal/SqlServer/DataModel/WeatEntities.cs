using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weat.Dal.SqlServer.DataModel
{
    public partial class WeatEntities
    {
        public WeatEntities(string connexion) : base(connexion)
        {

        }
    }
}
