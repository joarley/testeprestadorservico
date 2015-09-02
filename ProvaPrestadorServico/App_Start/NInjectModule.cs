using Ninject.Modules;
using ProvaPrestadorServico.Infra;
using ProvaPrestadorServico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPrestadorServico.App_Start
{
    class NInjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPesquisarEnderecoService>().To<PesquisarEnderecoServiceGMaps>();
            Bind<IPrestadorRepository>().ToConstant(new PrestadorRepositoryInMemory());
        }
    }
}
