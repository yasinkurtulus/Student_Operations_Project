using HotelResarvationBusinessLayer.Abstract;
using HotelResarvationBusinessLayer.Concrate;
using HotelResarvationDataAccessLayer.Abstract;
using HotelResarvationDataAccessLayer.Concrate;
using HotelResarvationDataAccessLayer.EntityFramework;
using HotelResarvationWebAp�.Mapping;
using ISubscribeDal = HotelResarvationDataAccessLayer.Abstract.ISubscribeDal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStaffService, StaffManager>();
builder.Services.AddScoped<IStaffDal, EfStaffDal>();


builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();


builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();


builder.Services.AddScoped<IRoomService, RoomManager>();
builder.Services.AddScoped<IRoomDal, EfRoomDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



builder.Services.AddDbContext<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("OtelApiCors");

app.UseAuthorization();


app.MapControllers();

app.Run();
