using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SkeletonAppWebApiContext context;
    private PaisRepository _paises;
    private DepartamentoRepository _departamento;


    public UnitOfWork(SkeletonAppWebApiContext _context)
    {
        context = _context;
    }
    public IPais Paises
    {
        get{
            if(_paises == null){
                _paises = new PaisRepository(context);
            }
            return _paises;
        }
    }
    public IDepartamento Departamentos
    {
        get{
            if(_departamento == null){
                _departamento = new DepartamentoRepository(context);
            }
            return _departamento;
        }
    }
    public void Dispose()
    {
        context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
