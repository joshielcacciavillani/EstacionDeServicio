using System;
using System.Collections.Generic;
using System.Linq;

public enum EstadoSurtidor {
    Bloqueado,
    Libre,
    Prefijado
}

public class Suministro {
    public int NumeroSurtidor { get; set; }
    public DateTime FechaHora { get; set; }
    public decimal ImportePrefijado { get; set; }
    public decimal ImporteSurtido { get; set; }
}

public class Surtidor {
    public EstadoSurtidor Estado { get; private set; }
    public decimal ImportePrefijado { get; private set; }
    public decimal MontoSuministrado { get; private set; }

    public Surtidor() {
        Estado = EstadoSurtidor.Bloqueado;
        ImportePrefijado = 0;
        MontoSuministrado = 0;
    }

    public void Liberar() {
        Estado = EstadoSurtidor.Libre;
        ImportePrefijado = 0; // Se borra el importe prefijado
    }

    public void Prefijar(decimal importe) {
        Estado = EstadoSurtidor.Prefijado;
        ImportePrefijado = importe;
    }

    public void Bloquear() {
        Estado = EstadoSurtidor.Bloqueado;
        ImportePrefijado = 0; // Se borra el importe prefijado
    }

    public Suministro FinalizarSuministro() {
        Suministro suministro = new Suministro {
            NumeroSurtidor = 0, // Asignar el número de surtidor adecuado
            FechaHora = DateTime.Now,
            ImportePrefijado = ImportePrefijado,
            ImporteSurtido = MontoSuministrado
        };

        MontoSuministrado = 0;
        Bloquear(); // El surtidor se bloquea al finalizar el suministro
        return suministro;
    }

    public void RegistrarSuministro(decimal monto) {
        MontoSuministrado += monto;
    }
}

public class Pista {
    private List<Surtidor> surtidores;
    private List<Suministro> historialSuministros;

    public Pista(int numSurtidores) {
        surtidores = new List<Surtidor>();
        historialSuministros = new List<Suministro>();

        for (int i = 0; i < numSurtidores; i++) {
            surtidores.Add(new Surtidor());
        }
    }

    public List<EstadoSurtidor> ObtenerEstado() {
        List<EstadoSurtidor> estados = new List<EstadoSurtidor>();
        foreach (var surtidor in surtidores) {
            estados.Add(surtidor.Estado);
        }
        return estados;
    }

    public void Suministro(decimal monto, bool prefijarMonto = false, decimal montoPrefijado = 0) {
        Surtidor surtidor = surtidores.Find(s => s.Estado == EstadoSurtidor.Bloqueado);
        if (surtidor != null) {
            surtidor.Liberar();
            if (prefijarMonto) {
                surtidor.Prefijar(montoPrefijado);
            }
            surtidor.RegistrarSuministro(monto);
            HistorialDeSuministros(surtidor.FinalizarSuministro());
        }
        else {
            Console.WriteLine("No hay surtidores disponibles para realizar el suministro.");
        }
    }


    public void HistorialDeSuministros(Suministro suministro) {
        historialSuministros.Add(suministro);
    }

    public void ImprimirHistorialSuministros() {
        // Ordenar los suministros por importe suministrado y fecha de realización
        var historialOrdenado = historialSuministros.OrderByDescending(s => s.ImporteSurtido).ThenByDescending(s => s.FechaHora);

        // Imprimir cada suministro en el historial
        foreach (var suministro in historialOrdenado) {
            Console.WriteLine($"Surtidor: {suministro.NumeroSurtidor}, " +
                              $"Fecha: {suministro.FechaHora}, " +
                              $"Importe Prefijado: {suministro.ImportePrefijado}, " +
                              $"Importe Surtido: {suministro.ImporteSurtido}");
        }
    }
}

class Program {
    static void Main(string[] args) {
        Pista pista = new Pista(3);

        pista.Suministro(30, prefijarMonto: true, montoPrefijado: 50);
        pista.Suministro(40);
        pista.Suministro(50, prefijarMonto: true, montoPrefijado: 60);
        pista.Suministro(60);
        pista.Suministro(70);

        Console.WriteLine("Historial de suministros:");
        pista.ImprimirHistorialSuministros();

        Console.ReadKey();
    }
}
