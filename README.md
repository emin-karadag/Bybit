![Bybit](https://github.com/emin-karadag/Bybit/blob/main/BybitApi/Bybit-Logo.png)

## Bybit C# API
Bybit borsasında, alım-satım yapmak veya piyasa verilerini çekmek için geliştirilen kullanımı kolay ve pratik bir .NET 7 - C# kütüphanesidir.


Bu kütüphane sadece [**Bybit**](https://www.bybit.com/) borsasını destekler.
Bybit'in herkese açık [API dokümanı](https://bybit-exchange.github.io/docs/v5/intro/) referans alınarak C# programlama dili ile Bybit için özel uygulama geliştirmek isteyenler için geliştirilmiştir.

### Lisans: 
    MIT License

## Özellikleri
- NuGet aracılığıyla yükleyebilme. ([BybitApi](https://www.nuget.org/packages/BybitApi/1.0.0))
- .NET 7 desteği. (Linux/MacOS uyumluluğu)
- RestAPI, [Bybit resmi dokümanının](https://bybit-exchange.github.io/docs/v5/intro/) büyük çoğunluğunu destekler.
	- Aktif olarak yeni özellikler eklenmeye devam edilecek.
- Genel ve özel API uç noktaları.
	- Özel API uç noktaları için Api Key ve Secret Key gerekmektedir.
- RestAPI, birden fazla kullanıcıyı destekler.  Her bir kullanıcı için API bilgilerini parametre olarak gönderebilirsiniz.
- Hataların daha kolay çözülebilmesi için Binance TR sunucularının geriye döndürdüğü **hata kodları** ve **hata mesajları** kullanılır.

## Başlangıç
Özel API uç noktalarını kullanabilmek için Bybit üzerinden hesap oluşturmanız gerekmektedir. Eğer hesabınız yok ise [buraya tıklayarak](https://www.bybit.com/invite?ref=DQ5YB) referansım üzerinden kaydolabilirsiniz.
> Halka açık piyasa verilerine erişmek için Bybit hesabı gerekli değildir!

## Kurulum
Bu kütüphane NuGet'te mevcuttur, indirmek için çekinmeyin. ([https://www.nuget.org/packages/BybitApi/1.0.0](https://www.nuget.org/packages/BybitApi/1.0.0 "https://www.nuget.org/packages/BybitApi/1.0.0"))

**NuGet PM**
```
Install-Package BybitApi -Version 1.0.0
```

**dotnet cli**
```
dotnet add package BybitApi --version 1.0.0
```
<!--
## Yol Haritası
Önümüzdeki süreçte `BinanceTR` kütüphanesine yeni özelliklerin eklenmesi ve genişletilmesi için çalışmalar yapılacaktır. Aşağıdaki tabloda üzerinde çalıştığımız yeni özellikleri görebilirsiniz.

| Özellik                 |    Durum     |  
|------------------------|:--------------:|
| OCO (Order-Cancel-Order) Desteği            |      ✔         |
| Hesap Ticaret Listesi (Account trade list)    |                |
| Para Çekme Talebi (Withdraw)                    |                |
| Para Çekme Geçmişi (Withdraw History)    |                |
| Para Yatırma Geçmişi (Deposit History)      |                |
| Para Yatırma Adresi (Deposit Address)       |                | |

!-->
## Örnek Kullanım (Halka Açık İşlemler)

**Bağımlılık Enjeksiyonu (Dependency Injection):**
```csharp
using Bybit.Business.Abstract;
using Bybit.Business.Concrete;

services.AddSingleton<IBybitService, BybitManager>();
```

**Constructor'da tanımalama:**
```csharp
using Bybit.Business.Abstract;

 private readonly IBybitService _bybitService;
 public Test(IBybitService bybitService)
 {
    _bybitService = bybitService;
 }
```

------------


**Bybit sunucuyu zaman bilgisini alın:**
```csharp
var serverTime = await _bybitService.Public.GetServerTimeAsync(stoppingToken);
if (!serverTime.Success)
{
    Console.WriteLine(serverTime.Message);
}
```

------------


**Borsa tarafından listelenen tüm sembolleri alın:**
```csharp
var model = new InstrumentsInfoDto
{
    Category = Models.Enums.CategoryEnum.SPOT,
};
var instrumentsResult = await _bybitService.Market.GetInstrumentsInfoAsync(model, stoppingToken);
var instrumentsInfo = instrumentsResult.Data;
```


> Yukarıdaki örnekler RestAPI'nin halka açık fonksiyonlarının kullanımına örnek olarak verilmiştir. Daha fazlası için kütüphaneyi indirip kullanabilirsiniz.

## Örnek Kullanım (Özel İşlemler)

**Bağımlılık Enjeksiyonu (Dependency Injection):**
```csharp
using Bybit.Business.Abstract;
using Bybit.Business.Concrete;

services.AddSingleton<IBybitService, BybitManager>();
```

**Constructor'da tanımalama:**
```csharp
using Bybit.Business.Abstract;

 private readonly IBybitService _bybitService;
 public Test(IBybitService bybitService)
 {
    _bybitService = bybitService;
 }
```

**Options tanımlama:**
```csharp
var options = new BybitOptions
{
   ApiKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxx",
   ApiSecret = "xxxxxxxxxxxxxxxxxxxxxxxx"
};
```

------------


**1. Limit tipinde yeni bir sipariş gönderin:**
Limit fiyatından yeni bir alış siparişi göndermek için aşağıdaki örneği kullanabilirsiniz.
```csharp
var options = new BybitOptions { ApiKey = _apiKey, SecretKey = _secretKey };
var model = new PlaceOrderDto
{
    Category = Models.Enums.CategoryEnum.SPOT,
    Side = Models.Enums.OrderSideEnum.BUY,
    Symbol = "BTCUSDT",
    Quantity = "0.0001",
    Price = "25000",
};
var placeOrderResult = await _bybitService.Trade.PlaceOrderAsync(options, model, stoppingToken).ConfigureAwait(false);
if (placeOrderResult.Success)
{
    // ...
}
```
<!--
------------


Limit fiyatından yeni bir satış siparişi göndermek için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.PostNewLimitOrderAsync(options, "BTC_TRY", OrderSideEnum.SELL, 0.002M, 500000, stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```

------------


**2. Market tipinde yeni bir sipariş gönderin:**
Market fiyatından yeni bir alış siparişi göndermek için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.PostBuyMarketOrderAsync(options, "BTC_TRY", 12, stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```

------------

Market fiyatından yeni bir satış siparişi göndermek için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.PostSellMarketOrderAsync(options, "BTC_TRY", 12, stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```


**3. Zarar - Durdur (Stop) siparişleri gönderin:**
Zarar - Durdur (Stop) siparişi göndermek için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.PostStopLimitOrderAsync(options, "BTC_TRY", OrderSideEnum.SELL, 0.000015M, 150000, 150000, stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```

**4. Siparişlerinizi iptal edin:**
Açmış olduğunuz siparişlerinizi iptal etmek için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.CancelOrderByIdAsync(options, 123456, stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```

**5. Sipariş detayını görüntüleyin:**
Açmış olduğunuz siparişe ait detay bilgiyi almak için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.GetOrderByIdAsync(options, 123456, stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```

**6. Tüm siparişlerinizi görüntüleyin:**
Bir sembole ait tüm siparişlerinize ait detay bilgiyi almak için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.GetAllOrdersAsync(options, "BTC_TRY", ct:stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```

**7. Tüm açık siparişlerinizi görüntüleyin:**
Bir sembole ait tüm açık siparişlerinize ait detay bilgiyi almak için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.GetAllOpenOrdersAsync(options, "BTC_TRY", ct:stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```


**8. Açık siparişlerinizi görüntüleyin:**
Bir sembole ait AL (BUY) tipindeki tüm açık siparişlerinize ait detay bilgiyi almak için aşağıdaki örneği kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.GetAllOpenBuyOrdersAsync(options, "BTC_TRY", ct:stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```


**9. Emir Emiri Bozar (Order Cancel Order - OCO) tipinde sipariş gönderin:**
Bir sembole ait aynı anda hem zarar durdur hem de hedef fiyat göndermek için OCO emir tipini kullanabilirsiniz.
```csharp
var orderResult = await _binanceTrService.Order.PostOcoOrderAsync(options, "BTC_TRY", OrderSideEnum.SELL, 0.000015M, 466000, 433000, 492000, stoppingToken).ConfigureAwait(false);
if (orderResult.Success)
{
	// ....
}
```


> Yukarıdaki örnekler RestAPI'nin özel fonksiyonlarının kullanımına örnek olarak verilmiştir. Özel fonksiyonları kullanabilmek için Binance TR üzerinden Api Key ve Secret Key oluşturmanız gerekmektedir. Daha fazlası için kütüphaneyi indirip kullanabilirsiniz.

------------
!-->
## Bağış Yap
Kütüphaneyi kullanıp beğendiyseniz destek olmak amaçlı bağışta bulunabilirsiniz. Aşağıda Bitcoin ve Ethereum için cüzdan adreslerim yer almaktadır.

<img src="https://cdn.worldvectorlogo.com/logos/tether-1.svg" width="24px"> **Tether (USDT) - TRC20:** `TC3ruh9qWbwAnCHGEkschnmcYUNxGumHJS`

<img src="https://cdn.worldvectorlogo.com/logos/bitcoin.svg" width="24px"> **Bitcoin (BTC) - ERC20:** `0x4a656a72fada0ccdef737ad8cc2e39686af5efbe`

<img src="https://cdn.worldvectorlogo.com/logos/ethereum-1.svg" width="18px"> **Ethereum - ETH:** `0x4a656a72fada0ccdef737ad8cc2e39686af5efbe`
