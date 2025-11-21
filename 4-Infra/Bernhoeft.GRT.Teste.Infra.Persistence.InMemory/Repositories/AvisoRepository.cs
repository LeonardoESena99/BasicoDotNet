using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Attributes;
using Bernhoeft.GRT.Core.EntityFramework.Infra;
using Bernhoeft.GRT.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bernhoeft.GRT.ContractWeb.Infra.Persistence.SqlServer.ContractStore.Repositories
{
    [InjectService(Interface: typeof(IAvisoRepository))]
    public class AvisoRepository : Repository<AvisoEntity>, IAvisoRepository
    {
        public AvisoRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IQueryable<AvisoEntity> GetIQueryable(TrackingBehavior tracking)
            => tracking is TrackingBehavior.NoTracking ? Set.AsNoTrackingWithIdentityResolution() : Set;

        public Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
            => this.GetIQueryable(tracking).Where(x => x.Ativo).ToListAsync();

        public Task<AvisoEntity> BuscarAvisoAsync(int Id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
            => this.GetIQueryable(tracking).FirstOrDefaultAsync(x => x.Id == Id && x.Ativo);

        public async Task<bool> CadastrarAvisoAsync(AvisoEntity aviso, CancellationToken cancellationToken = default)
        {
            Set.Add(aviso);
            return (await Db.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task<bool> EditarAvisoAsync(AvisoEntity aviso, CancellationToken cancellationToken = default)
        {
            var objReal = this.BuscarAvisoAsync(aviso.Id, TrackingBehavior.NoTracking);
            aviso.DataCriacao = objReal.Result.DataCriacao;
            aviso.Titulo = objReal.Result.Titulo;
            aviso.Ativo = objReal.Result.Ativo;

            Set.Entry(aviso).State = EntityState.Modified;
            return (await Db.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task<bool> AlterarStatusAvisoAsync(int avisoId, CancellationToken cancellationToken = default)
        {
            var objReal = await this.GetIQueryable(TrackingBehavior.Default).FirstOrDefaultAsync(x => x.Id == avisoId);
            objReal.Ativo = !objReal.Ativo;
            return (await Db.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}