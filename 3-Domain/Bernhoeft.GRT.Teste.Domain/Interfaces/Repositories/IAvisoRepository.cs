using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;

namespace Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories
{
    public interface IAvisoRepository : IRepository<AvisoEntity>
    {
        Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task<AvisoEntity> BuscarAvisoAsync(int Id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task<bool> CadastrarAvisoAsync(AvisoEntity aviso, CancellationToken cancellationToken = default);
        Task<bool> EditarAvisoAsync(AvisoEntity aviso, CancellationToken cancellationToken = default);
        Task<bool> AlterarStatusAvisoAsync(int avisoId, CancellationToken cancellationToken = default);
    }
}