using System;

class Motor
{
    private int litros_de_aceite;
    private int potencia;

    public Motor(int potencia)
    {
        this.potencia = potencia;
        this.litros_de_aceite = 0;
    }

    public int GetLitrosDeAceite() => litros_de_aceite;
    public int GetPotencia() => potencia;

    public void SetLitrosDeAceite(int litros) => litros_de_aceite = litros;
    public void SetPotencia(int potencia) => this.potencia = potencia;
}

class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double precio_acumulado;

    public Coche(string marca, string modelo, int potencia)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.motor = new Motor(potencia);
        this.precio_acumulado = 0;
    }

    public string GetMarca() => marca;
    public string GetModelo() => modelo;
    public double GetPrecioAcumulado() => precio_acumulado;
    public Motor GetMotor() => motor;

    public void AcumularAveria(double monto)
    {
        precio_acumulado += monto;
    }
}

class Garaje
{
    private Coche cocheActual;
    private string averiaActual;
    private int cochesAtendidos;

    public Garaje()
    {
        cocheActual = null;
        averiaActual = "";
        cochesAtendidos = 0;
    }

    public bool AceptarCoche(Coche coche, string averia)
    {
        if (cocheActual != null)
        {
            return false;
        }

        cocheActual = coche;
        averiaActual = averia;
        cochesAtendidos++;
        double costoAveria = new Random().NextDouble() * 500; // Importe aleatorio
        coche.AcumularAveria(costoAveria);

        if (averia == "aceite")
        {
            coche.GetMotor().SetLitrosDeAceite(coche.GetMotor().GetLitrosDeAceite() + 10);
        }

        return true;
    }

    public void DevolverCoche()
    {
        cocheActual = null;
        averiaActual = "";
    }
}

class PracticaPOO
{
    static void Main()
    {
        Garaje garaje = new Garaje();
        Coche coche1 = new Coche("Toyota", "Corolla", 120);
        Coche coche2 = new Coche("Honda", "Civic", 140);

        for (int i = 0; i < 2; i++)
        {
            while (!garaje.AceptarCoche(coche1, "aceite")) { }
            garaje.DevolverCoche();
            while (!garaje.AceptarCoche(coche2, "motor")) { }
            garaje.DevolverCoche();
        }

        Console.WriteLine($"{coche1.GetMarca()} {coche1.GetModelo()} - Precio Acumulado: {coche1.GetPrecioAcumulado():F2}, Litros de Aceite: {coche1.GetMotor().GetLitrosDeAceite()}");
        Console.WriteLine($"{coche2.GetMarca()} {coche2.GetModelo()} - Precio Acumulado: {coche2.GetPrecioAcumulado():F2}, Litros de Aceite: {coche2.GetMotor().GetLitrosDeAceite()}");
    }
}
