using ITelectFinal.Models;
using ITelectFinal.Services;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ITelectFinal.Data
{
    public static class DbInitializer
    {
        public static void EnsureCreatedAndSeed()
        {
            using var context = new AppDbContext();
            // Ensure schema exists. If a previous DB exists with missing tables,
            // EnsureCreated() will NOT automatically add them, so we recreate if needed.
            context.Database.EnsureCreated();

            // If any critical table is missing (old schema), recreate the whole DB.
            bool needsRecreate =
                !DatabaseHasTable(context, "Users") ||
                !DatabaseHasTable(context, "Customers") ||
                !DatabaseHasTable(context, "Products") ||
                !DatabaseHasTable(context, "Orders") ||
                !DatabaseHasTable(context, "OrderItems") ||
                !DatabaseHasTable(context, "Payments") ||
                !DatabaseHasTable(context, "WorkflowTasks");
            if (needsRecreate)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            var auth = new AuthService();

            // Seed Users
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = auth.HashPassword("admin123"),
                    Role = "Admin"
                });

                context.SaveChanges();
            }

            // Ensure Products (T-Shirt, Cap, Mug, Tote Bag, Notebook) exist
            var requiredProducts = new[]
            {
                new Product { ProductName = "T-Shirt", Category = "Apparel", BasePrice = 250.00m, Material = "Cotton" },
                new Product { ProductName = "Cap", Category = "Apparel", BasePrice = 150.00m, Material = "Adjustable" },
                new Product { ProductName = "Mug", Category = "Merch", BasePrice = 120.00m, Material = "Ceramic" },
                new Product { ProductName = "Tote Bag", Category = "Merch", BasePrice = 180.00m, Material = "Eco-friendly" },
                new Product { ProductName = "Notebook", Category = "Stationery", BasePrice = 100.00m, Material = "Printed cover" }
            };

            foreach (var rp in requiredProducts)
            {
                var existing = context.Products.FirstOrDefault(p => p.ProductName == rp.ProductName);
                if (existing == null)
                {
                    context.Products.Add(rp);
                }
            }
            context.SaveChanges();

            // Seed Customers
            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john@example.com",
                    PhoneNumber = "0917-000-0000",
                    Address = "Sample Street, City"
                });
                context.SaveChanges();
            }

            // Seed Orders + OrderItems + initial WorkflowTask
            if (!context.Orders.Any())
            {
                var adminUser = context.Users.First();
                var customer = context.Customers.First();
                var product = context.Products.First();

                var order = new Order
                {
                    CustomerId = customer.CustomerId,
                    CreatedByUserId = adminUser.UserId,
                    OrderDate = DateTime.Now,
                    OrderStatus = "Pending",
                    TotalAmount = product.BasePrice,
                };

                order.Items.Add(new OrderItem
                {
                    Product = product,
                    ProductId = product.ProductId,
                    Quantity = 1,
                    UnitPrice = product.BasePrice,
                    Order = order,
                });

                context.Orders.Add(order);
                context.SaveChanges();

                context.WorkflowTasks.Add(new WorkflowTask
                {
                    OrderId = order.OrderId,
                    TaskName = "Order Processing",
                    TaskDescription = "Not paid yet",
                    AssignedRole = "Prod. Staff",
                    Status = "Pending",
                    LastUpdated = DateTime.Now
                });

                context.SaveChanges();
            }

            // Hardening: ensure every existing order has workflow tasks.
            // If the DB was created earlier (older schema/seeding), you can end up with orders but missing WorkflowTasks.
            var existingOrders = context.Orders.ToList();
            foreach (var order in existingOrders)
            {
                var tasksForOrder = context.WorkflowTasks.Where(t => t.OrderId == order.OrderId).ToList();
                var isCompleted = string.Equals(order.OrderStatus, "Completed", StringComparison.OrdinalIgnoreCase);

                var expectedStatus = isCompleted ? "Completed" : "Pending";
                var expectedDescription = isCompleted ? "Completed." : "Not paid yet";

                if (tasksForOrder.Count == 0)
                {
                    context.WorkflowTasks.Add(new WorkflowTask
                    {
                        OrderId = order.OrderId,
                        TaskName = "Order Processing",
                        TaskDescription = expectedDescription,
                        AssignedRole = "Prod. Staff",
                        Status = expectedStatus,
                        LastUpdated = DateTime.Now
                    });
                }
                else
                {
                    // Align any existing tasks with the order status (so Home splits Pending/InProgress/Completed correctly).
                    foreach (var t in tasksForOrder)
                    {
                        if (!string.Equals(t.Status, expectedStatus, StringComparison.OrdinalIgnoreCase))
                        {
                            t.Status = expectedStatus;
                            t.LastUpdated = DateTime.Now;
                        }

                        if (!string.Equals(t.TaskDescription, expectedDescription, StringComparison.OrdinalIgnoreCase))
                        {
                            t.TaskDescription = expectedDescription;
                            t.LastUpdated = DateTime.Now;
                        }
                    }
                }
            }
            context.SaveChanges();

            // Seed Payments (so at least one order is completed)
            if (!context.Payments.Any())
            {
                var completedCandidate = context.Orders.FirstOrDefault();
                if (completedCandidate != null)
                {
                    var adminUser = context.Users.First();
                    var payment = new Payment
                    {
                        OrderId = completedCandidate.OrderId,
                        AmountPaid = completedCandidate.TotalAmount,
                        PaymentMethod = "Cash",
                        PaymentDate = DateTime.Now,
                        ProcessedByUserId = adminUser.UserId
                    };

                    context.Payments.Add(payment);

                    // Update order + workflow to reflect payment
                    completedCandidate.OrderStatus = "Completed";
                    context.Orders.Update(completedCandidate);

                    var tasks = context.WorkflowTasks.Where(t => t.OrderId == completedCandidate.OrderId).ToList();
                    foreach (var t in tasks)
                    {
                        t.Status = "Completed";
                        t.TaskDescription = "Completed.";
                        t.LastUpdated = DateTime.Now;
                    }

                    context.SaveChanges();
                }
            }
        }

        private static bool DatabaseHasTable(AppDbContext context, string tableName)
        {
            // Works even if the table doesn't exist yet.
            var dbPath = DbPath.GetDatabasePath();
            var conn = new SqliteConnection($"Data Source={dbPath}");
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "SELECT name FROM sqlite_master WHERE type='table' AND name=$name LIMIT 1;";
                var p = cmd.CreateParameter();
                p.ParameterName = "$name";
                p.Value = tableName;
                cmd.Parameters.Add(p);

                var result = cmd.ExecuteScalar();
                return result != null;
            }
            finally
            {
                // Keep connection lifecycle minimal
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}

