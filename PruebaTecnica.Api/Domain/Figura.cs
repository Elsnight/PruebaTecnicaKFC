namespace PruebaTecnica.Api.Domain;


public abstract class Figura
{
    public abstract double Area();
}


public class Circulo : Figura
{
    public double Radio { get; init; }
    public Circulo(double r) => Radio = r;
    public override double Area() => Math.PI * Radio * Radio;
}


public class Rectangulo : Figura
{
    public double Ancho { get; init; }
    public double Alto { get; init; }
    public Rectangulo(double a, double b) { Ancho = a; Alto = b; }
    public override double Area() => Ancho * Alto;
}


// Interfaz (contrato)
public interface IImprimible { string Imprimir(); }


public class FiguraImprimibleAdapter : IImprimible
{
    private readonly Figura _fig;
    public FiguraImprimibleAdapter(Figura f) => _fig = f;
    public string Imprimir() => $"Área = {_fig.Area():0.##}";
}