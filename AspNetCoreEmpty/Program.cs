var builder = WebApplication.CreateBuilder(args);
// 1 Controllerlar ve geri dönülecek servisi ekliyorum.

// Controller ve View'larýn kullanýlacaðýný belirtiyoruz
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// HTTPS yönlendirmesi: HTTP'den gelen istekler HTTPS'ye yönlendirilir
app.UseHttpsRedirection();

//Static dosyalarý(CSS, JS, img) kullanmayý saðlar
app.UseStaticFiles();

//Routing mekanizmasýný aktif hale getirir
app.UseRouting();

// Authorization'ý aktif eder
app.UseAuthorization();


// Default olarak açýlacak olan sayfa ve yönlendirme yapýlandýrmasý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


/*
 * MVC mimarisi þu þekilde çalýþýr: Tarayýcýdan View sayfasýna istek yapýldýðýnda, View katmaný Controller’a gider. Controller isteði gerçekleþtirmek üzere Model katmanýna gider. Daha sonra Model'den alýnan veriler, View’a gönderilerek istenilen verilerin görüntülenmesi saðlanýr. En basit anlamda MVC, bir uygulamayý üç alana ayýrma çabasýdýr. 
 * 
 Model: MVC mimarisi içinde verilerin tutulduðu, veri tabanýna eriþimin saðlandýðý, tüm data iþlemlerinin gerçekleþtiði yer model katmanýdýr. Veriler burada iþlenir ve sorgularý burada yapýlýr. Diðer yandan somut nesnelerin bilgisayar ortamda anlamlaþtýrýlmasý yani modellenmesi anlamýna gelir. Bunlar veri, dosya veya basit nesneler de olabilir. Örneðin bir müþteri web sitesine kayýt olduðunda onunla ilgili isim, yaþ, cinsiyet ve konum gibi bilgiler modelde tutulur. 
 *

View: View, Model katmanýnýn görselleþtirilmiþ, kullanýcýnýn uygulamayý gördüðü halidir. Kullanýcýnýn görebileceði her þey View katmanýndadýr.  Metin kutularý, menüler gibi tüm UI bileþenlerini içerir. Html, Css, Javascript gibi arayüz teknolojilerinden yararlanýr. 

WwwRoot : Css, Javascript dosyalarý, resimler gibi, browser ýn ulaþmasý gereken tüm dosyalarýmý koyacaðýmýz yerdir.
 
*
Controller: Model ve View katmanlarý arasýndaki iþlemleri gerçekleþtirir. Yani View katmanýndan aldýðý veri tabaný iþlemleri ve hesaplamalar gibi tüm iþlemleri Model katmanýna taþýr. Bir nevi arada köprü görevi görür. 

 
 */

/*
 

1. builder.Build()
builder.Build(), ASP.NET Core uygulamalarýnda kullanýlan WebApplicationBuilder nesnesini tamamlayýp bir WebApplication nesnesi oluþturan metottur. Bu metot, uygulamanýn tüm yapýlandýrmasýný (middleware, servisler vb.) tamamladýktan sonra uygulamayý çalýþtýrmaya hazýr hale getirir. builder.Build() çaðrýsýndan sonra uygulama, app.Run() gibi iþlemlerle istekleri dinlemeye baþlar.

2. app.Run()
app.Run(), ASP.NET Core uygulamalarýnda middleware pipeline'ýn son halkasýdýr. Uygulama baþlatýldýðýnda HTTP isteklerine yanýt verir ve middleware zincirini sonlandýrýr. Genellikle, uygulama dinlemeye baþlar ve isteklere yanýt döndürür.

Kýsaca app.Run(), uygulamanýn ana döngüsünü baþlatýr ve sunucunun çalýþmasýna olanak tanýr. Genellikle uygulamanýn sonunda çaðrýlýr ve uygulama çalýþmaya devam ettiði sürece bu metot kesintisiz olarak çalýþýr.
app.Run() ile sunucu baþlatýlýr ve uygulama istekleri dinlemeye baþlar.
 */