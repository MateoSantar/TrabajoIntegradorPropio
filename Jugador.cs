using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoIntegrador
{
    public class Jugador
    {
        private string nombre, nacionalidad, position, equipo;
        private DateTime fechaNacimiento;
        private int goles,asistencias,pasesTotales,faltasRecibidas,lesionesSufridas;
        private double valorMercado;

        public Jugador(string nombre, string nacionalidad, string position,string equipo, DateTime fechaNacimiento, int goles, int asistencias, int pasesTotales, int faltasRecibidas, int lesionesSufridas, double valorMercado)
        {
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
            this.position = position;
            this.equipo = equipo;
            this.fechaNacimiento = fechaNacimiento;
            this.goles = goles;
            this.asistencias = asistencias;
            this.pasesTotales = pasesTotales;
            this.faltasRecibidas = faltasRecibidas;
            this.lesionesSufridas = lesionesSufridas;
            this.valorMercado = valorMercado;
        }
        public Jugador(double valorMercado)
        {
            this.valorMercado = valorMercado;
        }
        public Jugador(int pasesTotales)
        {
            this.pasesTotales= pasesTotales;
        }
        public Jugador()
        {

        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Position { get => position; set => position = value; }
        public string Equipo { get => equipo; set => equipo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Goles { get => goles; set => goles = value; }
        public int Asistencias { get => asistencias; set => asistencias = value; }
        public int PasesTotales { get => pasesTotales; set => pasesTotales = value; }
        public int FaltasRecibidas { get => faltasRecibidas; set => faltasRecibidas = value; }
        public int LesionesSufridas { get => lesionesSufridas; set => lesionesSufridas = value; }
        public double ValorMercado { get => valorMercado; set => valorMercado = value; }
        public override string ToString()
        {
            string s = $"Nombre = {nombre} | Nacionalidad = {nacionalidad} | Posición = {position} | Equipo = {equipo}" +
                $"\nNacimiento = {fechaNacimiento:d} | Goles = {goles} | Asistencias = {asistencias}" +
                $"\nPases totales = {pasesTotales} | Faltas recibidas = {faltasRecibidas} | Lesiones sufridas = {lesionesSufridas} | " +
                $"Valor en el mercado = ${valorMercado:n2}\n";
            return s;
        }
    }
}
