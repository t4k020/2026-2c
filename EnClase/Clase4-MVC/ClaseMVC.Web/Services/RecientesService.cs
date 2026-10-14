using System.Collections.Generic;
using System.Linq;
using ClaseMVC.Web.Extensions;
using Microsoft.AspNetCore.Http;

namespace ClaseMVC.Web.Services;

public class RecientesService : IRecientesService
{
    private const string SessionKey = "Recientes";
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly int _limit = 5;

    public RecientesService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ISession Session => _httpContextAccessor.HttpContext!.Session;

    public List<int> ObtenerRecientes()
    {
        return Session.GetObject<List<int>>(SessionKey) ?? new List<int>();
    }

    public void AgregarReciente(int id)
    {
        var recientes = ObtenerRecientes();
        recientes.RemoveAll(x => x == id);
        recientes.Insert(0, id);
        if (recientes.Count > _limit)
            recientes = recientes.Take(_limit).ToList();
        Session.SetObject(SessionKey, recientes);
    }

    public void LimpiarRecientes()
    {
        Session.SetObject(SessionKey, new List<int>());
    }
}
