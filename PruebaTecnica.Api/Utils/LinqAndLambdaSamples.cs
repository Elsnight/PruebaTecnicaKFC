using System.Collections.Generic;
using System.Linq;


namespace PruebaTecnica.Api.Utils;


public static class LinqAndLambdaSamples
{
    public static List<int> DoblarParesConList(List<int> numeros)
    => numeros.Where(n => n % 2 == 0).Select(n => n * 2).ToList();


    public static HashSet<int> UnicosConHashSet(IEnumerable<int> numeros)
    => new HashSet<int>(numeros); // remueve duplicados en O(1) promedio por inserción


    public static (int encontrados, bool contieneCinco) CompararRendimientoBasico()
    {
        var lista = Enumerable.Range(1, 100_000).ToList();
        var set = new HashSet<int>(lista);
        // Contiene en List = O(n), en HashSet = O(1) promedio
        int hits = 0;
        foreach (var x in new[] { 5, 50_000, 100_000 })
        {
            if (lista.Contains(x)) hits++;
        }
        return (hits, set.Contains(5));
    }
}