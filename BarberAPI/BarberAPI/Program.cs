using Microsoft.EntityFrameworkCore;

namespace BarberAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionar serviços ao contêiner
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); // Necessário para o Swagger
            builder.Services.AddSwaggerGen();           // Adiciona o Swagger para a documentação da API

            // Configurar o DbContext com a string de conexão
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseSwagger();     // Ativa o gerador de documentação Swagger em desenvolvimento
            app.UseSwaggerUI();   // Ativa a interface Swagger UI para interações no navegador

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
