using ElevenNoteSOAP.Data;
using ElevenNoteSOAP.Services.CategoryServices;
using ElevenNoteSOAP.Services.NoteServices;
using Microsoft.EntityFrameworkCore;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
                opt=>
                opt.UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<INoteService,NoteService>();
builder.Services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endponts =>
{
    endponts.MapControllers();
    endponts.UseSoapEndpoint<ICategoryService>("/ElevenNoteCategories.asmx",new SoapEncoderOptions(),SoapSerializer.XmlSerializer);
    endponts.UseSoapEndpoint<INoteService>("/ElevenNoteNotes.asmx",new SoapEncoderOptions(),SoapSerializer.XmlSerializer);
});

app.Run();
