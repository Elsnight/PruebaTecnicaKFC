using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace PruebaTecnica.Api.Utils;


public static class ConcurrencySamples
{
    private static readonly SemaphoreSlim _semaforo = new(3); // limitar a 3 concurrencias


    public static async Task<string> DescargarSeguroAsync(HttpClient http, string url, CancellationToken ct)
    {
        await _semaforo.WaitAsync(ct);
        try
        {
            using var res = await http.GetAsync(url, ct);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadAsStringAsync(ct);
        }
        finally
        {
            _semaforo.Release();
        }
    }
}