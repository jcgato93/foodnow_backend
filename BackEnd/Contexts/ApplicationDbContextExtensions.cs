using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;


namespace BackEnd.Contexts
{
    public static class ApplicationDbContextExtensions
    {
        // Inserta la data por defecto en la base de datos
        public static void EnsureDatabaseSeeded(this ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new Category[]
                    {
                        new Category()
                        {
                            Name = "Comidas"
                        },
                        new Category()
                        {
                            Name = "Bebidas"
                        },
                        new Category()
                        {
                            Name = "Entradas"
                        },
                        new Category()
                        {
                            Name = "Postres"
                        },
                        new Category()
                        {
                            Name = "Licores"
                        },
                        new Category()
                        {
                            Name = "Otros"
                        }
                    }

                );

                context.SaveChanges();
            }

            if(!context.PayTypes.Any())
            {
                context.PayTypes.AddRange(new PayType[]
                {
                    new PayType{ description = "Efectivo" },
                    new PayType{ description = "Tarjeta"}
                });

                context.SaveChanges();
            }

            if(!context.States.Any())
            {                
                context.States.AddRange(new State[]
                {
                    // Cuando el cliente realiza el pedido de los productos
                    new State{description="Solicitado"},

                    // Cuando el pedido es cancelado
                    new State{description="Cancelado"},

                    // Cuando el pedido ha sido pagado
                    new State{description="Pagado"},

                    // Cuando el pedido esta en proceso de preparacion
                    new State{description="En Proceso"},

                    // Cuando se entrega el pedido al cliente
                    new State{description="Entregado"}
                });

                context.SaveChanges();
            }
        }
    }
}
