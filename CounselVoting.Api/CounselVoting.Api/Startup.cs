using CounselVoting.Infrastructure.Context;
using CounselVoting.Infrastructure.Repository;
using CounselVoting.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CounselVoting.Domain.Mappers;
using CounselVoting.Domain.ViewModel;
using CounselVoting.Domain.Model;
using CounselVoting.Api.Service;
using Microsoft.EntityFrameworkCore;

namespace CounselVoting.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CounselContext>((serviceProvider, options) =>
            {
                var connectionString = Configuration.GetSection("ConnectionString").Value;
                options.UseSqlite(connectionString);
            });

            //REPOSITORIES
            services.AddScoped(typeof(CounselVotingRepository<>), typeof(CounselVotingRepository<>));


            //SERVICES 
            services.AddScoped<IMeasureRuleServiceData, MeasureRuleServiceData>();
            services.AddScoped<IVoteServiceData, VoteServiceData>();
            services.AddScoped<IVoteService, VoteService>();

            services.AddScoped(typeof(IMapper<VoteModel, VoteRequest>), typeof(VoteMapper));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:5174")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CounselVoting.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CounselVoting.Api v1"));
            }

            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
