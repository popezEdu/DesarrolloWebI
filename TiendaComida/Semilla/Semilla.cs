using System;
using TiendaComida.Data;
using TiendaComida.Entidades;

namespace TiendaComida.Semilla;

public class Semilla
{

    public static async Task Poblar(AppDbContext contexto)
    {
        if (contexto.Productos.Any()) return;

        var productos = new List<Producto>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Nombre = "COCA COLA DE TRES LITROS",
                Descripcion = "GASEOSA",
                Costo = 15,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Internacional,
                EstaVigente = true,
                EsPlato = false,
                TieneAlcohol = false
            },
            new()
            {
                Id = Guid.NewGuid(),
                Nombre = "PETT COLA",
                Descripcion = "GASEOSA",
                Costo = 8.5M,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Nacional,
                EstaVigente = true,
                EsPlato = false,
                TieneAlcohol = false
            },
            new()
            {
                Id = Guid.NewGuid(),
                Nombre = "COCA COLA DE DOS LITROS",
                Descripcion = "GASEOSA",
                Costo = 10,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Internacional,
                EstaVigente = true,
                EsPlato = false,
                TieneAlcohol = false
            },
            new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "CALAMAR",
                Descripcion = "MARITIMO",
                Costo = 100,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Internacional,
                EstaVigente = false,
                EsPlato = true,
                TieneAlcohol = false
            },
            new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "PACEÑA MACANUDA",
                Descripcion = "PRODUCTO CBN",
                Costo = 25,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Ambos,
                EstaVigente = true,
                EsPlato = false,
                TieneAlcohol = true
            },
            new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "SAICE",
                Descripcion = "PLATO TIPICO TARIJEÑO",
                Costo = 10,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Nacional,
                EstaVigente = true,
                EsPlato = true,
                TieneAlcohol = false
            },
            new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "ARANJUEZ TERRUÑO",
                Descripcion = "PRODUCTO TARIJEÑO",
                Costo = 18.5M,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Nacional,
                EstaVigente = true,
                EsPlato = false,
                TieneAlcohol = true
            },
            new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "TALLARIN DE CARNE",
                Descripcion = "CONTIENE FIDEOS",
                Costo = 15,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Internacional,
                EstaVigente = true,
                EsPlato = true,
                TieneAlcohol = false
            },
            new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "PIQUE A LO MACHO",
                Descripcion = "PLATO COCHABAMBINO",
                Costo = 30,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Nacional,
                EstaVigente = true,
                EsPlato = true,
                TieneAlcohol = false
            },
            new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "MAJADO",
                Descripcion = "PLATO CRUCEÑO",
                Costo = 20,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Nacional,
                EstaVigente = true,
                EsPlato = true,
                TieneAlcohol = false
            },
               new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "TALLARIN DE POLLO",
                Descripcion = "CONTIENE FIDEOS",
                Costo = 15,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Internacional,
                EstaVigente = true,
                EsPlato = true,
                TieneAlcohol = false
            },
               new ()
            {
                 Id = Guid.NewGuid(),
                Nombre = "PARRILLADA DE CARNE",
                Descripcion = "AOMPAÑADO DE GUARNICIONES",
                Costo = 50,
                Clasificacion = Enumeraciones.Conceptos.TiposDePlatos.Internacional,
                EstaVigente = true,
                EsPlato = true,
                TieneAlcohol = false
            },

        };

        contexto.Productos.AddRange(productos);

        await contexto.SaveChangesAsync();
    }

}
