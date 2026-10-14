using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using ClaseMVC.Web.Services;
using ClaseMVC.Web.Extensions;
using Xunit;
using System.Text.Json;

namespace ClaseMVC.Web.Tests;

public class FakeSession : ISession
{
    private readonly Dictionary<string, byte[]> _store = new();
    public IEnumerable<string> Keys => _store.Keys;
    public string Id { get; } = System.Guid.NewGuid().ToString();
    public bool IsAvailable { get; } = true;
    public void Clear() => _store.Clear();
    public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    public void Remove(string key) => _store.Remove(key);
    public void Set(string key, byte[] value) => _store[key] = value;
    public bool TryGetValue(string key, out byte[] value) => _store.TryGetValue(key, out value);
}

public class RecientesServiceTests
{
    private IHttpContextAccessor CreateAccessorWithSession(ISession session)
    {
        var context = new DefaultHttpContext();
        // Assign the fake session directly
        context.Session = session;
        return new HttpContextAccessor { HttpContext = context };
    }

    [Fact]
    public void AgregarReciente_MantieneOrdenYLimiteYSinDuplicados()
    {
        var session = new FakeSession();
        var accessor = CreateAccessorWithSession(session);
        var service = new RecientesService(accessor);

        // add 6 ids -> limit 5
        for (int i = 1; i <= 6; i++)
        {
            service.AgregarReciente(i);
        }

        var actuales = service.ObtenerRecientes();
        Assert.Equal(5, actuales.Count);
        // newest first -> 6,5,4,3,2
        Assert.Equal(new List<int> {6,5,4,3,2}, actuales);

        // add duplicate (3) -> should move to front and not duplicate
        service.AgregarReciente(3);
        actuales = service.ObtenerRecientes();
        Assert.Equal(5, actuales.Count);
        Assert.Equal(new List<int> {3,6,5,4,2}, actuales);
    }

    [Fact]
    public void ObtenerRecientes_Vacio_IniciaVacio()
    {
        var session = new FakeSession();
        var accessor = CreateAccessorWithSession(session);
        var service = new RecientesService(accessor);

        var actuales = service.ObtenerRecientes();
        Assert.NotNull(actuales);
        Assert.Empty(actuales);
    }

    [Fact]
    public void LimpiarRecientes_VaciaLista()
    {
        var session = new FakeSession();
        var accessor = CreateAccessorWithSession(session);
        var service = new RecientesService(accessor);

        service.AgregarReciente(1);
        service.AgregarReciente(2);
        Assert.NotEmpty(service.ObtenerRecientes());

        service.LimpiarRecientes();
        Assert.Empty(service.ObtenerRecientes());
    }
}
