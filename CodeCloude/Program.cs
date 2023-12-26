using CodeCloude.Api.Bll;
using CodeCloude.Api.Services;
using CodeCloude.Api.Services.BLL;
using CodeCloude.BLL;
using CodeCloude.Data;
using CodeCloude.Extend;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static CodeCloude.Api.Bll.SliderApiRep;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson();

builder.Services.AddDbContext<CodeCloude_DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection"));
});

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors();
IdentityBuilder identityBuilder = builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {

    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<CodeCloude_DbContext>()
  .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

//start Add Transient
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddTransient<IAddition_TermsRep, Addition_TermsRep>();
builder.Services.AddTransient<ICategoriesRep, CategoriesRep>();
builder.Services.AddTransient<ICountriesRep, CountriesRep>();
builder.Services.AddTransient<IUser_FaviouritesRep, User_FaviouritesRep>();
builder.Services.AddTransient<IprivacypolicyRep, privacypolicyRep>();
builder.Services.AddTransient<IQuestionsRep, QuestionsRep>();
builder.Services.AddTransient<ISliderRep, SliderRep>();
builder.Services.AddTransient<IStoresRep, StoresRep>();
builder.Services.AddTransient<ITerms_ConditionsRep, Terms_ConditionsRep>();
builder.Services.AddTransient<IContcatUsRep, ContcatUsRep>();
builder.Services.AddTransient<ISubscriptionsRep, SubscriptionsRep>();
builder.Services.AddTransient<ISubscripeRequestsRep, SubscripeRequestsRep>();
builder.Services.AddTransient<IUserSubscriptionRep, UserSubscriptionRep>();
builder.Services.AddTransient<IBankDetailsRep, BankDetailsRep>();

//End Add Transient

//start Add Api Transient

//builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISliderApiRep, SliderApiRep>();
builder.Services.AddTransient<IAddition_TermsApiRep, Addition_TermsApiRep>();
builder.Services.AddTransient<IprivacypolicyApiRep, privacypolicyApiRep>();
builder.Services.AddTransient<ITerms_ConditionsApiRep, Terms_ConditionsApiRep>();
builder.Services.AddTransient<IQuestionsApiRep, QuestionsApiRep>();

builder.Services.AddTransient<ICategoriesApiRep, CategoriesApiRep>();
builder.Services.AddTransient<ICountriesApiRep, CountriesApiRep>();
builder.Services.AddTransient<IStoresApiRep, StoresApiRep>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IContcatUsApiRep, ContcatUsApiRep>();
builder.Services.AddTransient<ISubscriptionsApiRep, SubscriptionsApiRep>();
builder.Services.AddTransient<ISubscripeRequestsApiRep, SubscripeRequestsApiRep>();
builder.Services.AddTransient<IUser_FaviouritesApiRep, User_FaviouritesApiRep>();
builder.Services.AddTransient<IBankDetailsApiRep, BankDetailsApiRep>();


//End Add Api Transient

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
