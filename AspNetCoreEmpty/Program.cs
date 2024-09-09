var builder = WebApplication.CreateBuilder(args);
// 1 Controllerlar ve geri d�n�lecek servisi ekliyorum.

// Controller ve View'lar�n kullan�laca��n� belirtiyoruz
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// HTTPS y�nlendirmesi: HTTP'den gelen istekler HTTPS'ye y�nlendirilir
app.UseHttpsRedirection();

//Static dosyalar�(CSS, JS, img) kullanmay� sa�lar
app.UseStaticFiles();

//Routing mekanizmas�n� aktif hale getirir
app.UseRouting();

// Authorization'� aktif eder
app.UseAuthorization();


// Default olarak a��lacak olan sayfa ve y�nlendirme yap�land�rmas�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


/*
 * MVC mimarisi �u �ekilde �al���r: Taray�c�dan View sayfas�na istek yap�ld���nda, View katman� Controller�a gider. Controller iste�i ger�ekle�tirmek �zere Model katman�na gider. Daha sonra Model'den al�nan veriler, View�a g�nderilerek istenilen verilerin g�r�nt�lenmesi sa�lan�r. En basit anlamda MVC, bir uygulamay� �� alana ay�rma �abas�d�r. 
 * 
 Model: MVC mimarisi i�inde verilerin tutuldu�u, veri taban�na eri�imin sa�land���, t�m data i�lemlerinin ger�ekle�ti�i yer model katman�d�r. Veriler burada i�lenir ve sorgular� burada yap�l�r. Di�er yandan somut nesnelerin bilgisayar ortamda anlamla�t�r�lmas� yani modellenmesi anlam�na gelir. Bunlar veri, dosya veya basit nesneler de olabilir. �rne�in bir m��teri web sitesine kay�t oldu�unda onunla ilgili isim, ya�, cinsiyet ve konum gibi bilgiler modelde tutulur. 
 *

View: View, Model katman�n�n g�rselle�tirilmi�, kullan�c�n�n uygulamay� g�rd��� halidir. Kullan�c�n�n g�rebilece�i her �ey View katman�ndad�r.  Metin kutular�, men�ler gibi t�m UI bile�enlerini i�erir. Html, Css, Javascript gibi aray�z teknolojilerinden yararlan�r. 

WwwRoot : Css, Javascript dosyalar�, resimler gibi, browser �n ula�mas� gereken t�m dosyalar�m� koyaca��m�z yerdir.
 
*
Controller: Model ve View katmanlar� aras�ndaki i�lemleri ger�ekle�tirir. Yani View katman�ndan ald��� veri taban� i�lemleri ve hesaplamalar gibi t�m i�lemleri Model katman�na ta��r. Bir nevi arada k�pr� g�revi g�r�r. 

 
 */

/*
 

1. builder.Build()
builder.Build(), ASP.NET Core uygulamalar�nda kullan�lan WebApplicationBuilder nesnesini tamamlay�p bir WebApplication nesnesi olu�turan metottur. Bu metot, uygulaman�n t�m yap�land�rmas�n� (middleware, servisler vb.) tamamlad�ktan sonra uygulamay� �al��t�rmaya haz�r hale getirir. builder.Build() �a�r�s�ndan sonra uygulama, app.Run() gibi i�lemlerle istekleri dinlemeye ba�lar.

2. app.Run()
app.Run(), ASP.NET Core uygulamalar�nda middleware pipeline'�n son halkas�d�r. Uygulama ba�lat�ld���nda HTTP isteklerine yan�t verir ve middleware zincirini sonland�r�r. Genellikle, uygulama dinlemeye ba�lar ve isteklere yan�t d�nd�r�r.

K�saca app.Run(), uygulaman�n ana d�ng�s�n� ba�lat�r ve sunucunun �al��mas�na olanak tan�r. Genellikle uygulaman�n sonunda �a�r�l�r ve uygulama �al��maya devam etti�i s�rece bu metot kesintisiz olarak �al���r.
app.Run() ile sunucu ba�lat�l�r ve uygulama istekleri dinlemeye ba�lar.
 */