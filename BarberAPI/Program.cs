using Microsoft.EntityFrameworkCore;

namespace BarberAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionar servi�os ao cont�iner
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); // Necess�rio para o Swagger
            builder.Services.AddSwaggerGen();           // Adiciona o Swagger para a documenta��o da API

            // Configurar o DbContext com a string de conex�o
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseSwagger();     // Ativa o gerador de documenta��o Swagger em desenvolvimento
            app.UseSwaggerUI();   // Ativa a interface Swagger UI para intera��es no navegador

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
