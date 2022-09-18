<img src="https://soliteacr.visualstudio.com/iDoklad/_apis/build/status/SDK/IdokladSdk?branchName=master">

# SDK for iDoklad API

SDK targets .NET Standard 2.0

[Documentation for latest version of API can be found here](https://api.idoklad.cz/Help/v3/en/)

# Application

**iDoklad** is online accounting from Solitea. Ideal for self employed and small businesses. The easiest way to conveniently create, print and manage your invoices online from anywhere. Get started now!

[iDoklad.cz](https://www.idoklad.cz/)  
[iDoklad.sk](https://www.idoklad.sk/)

## NuGet

You can install **SDK for iDoklad API** using the [NuGet](https://www.nuget.org/packages/IdokladSdk)

```cmd
> dotnet add package IdokladSdk
```

# Quick start (examples)

## Basic

### 1. Authenticate and initialize API

```csharp
// Use DokladApiBuilder to create DokladApi.
var api = new DokladApiBuilder("your application name", "your application version")
        .AddClientCredentialsAuthentication("ClientId", "ClientSecret")
        .Build();
```

### 2. Use it!

```csharp
// All methods are exposed as synchronous and asynchronous.
// Use whichever is more convenient to you.
var issuedInvoiceResult = await api.IssuedInvoiceClient.Detail(123456).GetAsync();

// All of our methods return ApiResult or ApiBatchResult containing information about response and the data you requested.
// You can access them using property or call method CheckResult()
// These next two lines return the same data
var issuedInvoice1 = issuedInvoiceResult.Data;
var issuedInvoice2 = issuedInvoiceResult.CheckResult();

// Using the same DokladApi instance, you can access all available endpoints, no need to create separate instances.
var contact = (await api.ContactClient.List().GetAsync()).Data;

// In order to change language and send it in requests you have to set it first.
// The default is Language.Cz
_api.ApiContext.SetLanguage(Language.En);
```

## Advanced

### 3. Error handling

Classes _ApiResult_ and _ApiBatchResult_ contain method _CheckResult()_ which will throw exception if the response is unsuccessful, otherwise it will return your data.

```csharp
var models = new List<UpdateExportedModel>() { ... }; // non empty list
var batchResult = await _api.BatchClient.UpdateAsync(models); // returns ApiBatchResult
var batchData = batchResult.CheckResult();

var issuedInvoiceResult = await api.IssuedInvoiceClient.DefaultAsync(); // returns ApiResult
var issuedInvoice = issuedInvoiceResult.CheckResult();
```

ApiContext contains handlers, which are called right after the response is received. We run our basic check to validate the response and these handlers are called right after that.  
**You can define your own handlers.** These can be useful, if you want to handle each kind of error differently and in one place.

```csharp
Action<ApiResult> handleApiResult = (ApiResult apiResult) =>
{
    switch (apiResult.StatusCode)
    {
        case HttpStatusCode.BadRequest:
            throw new InvalidOperationException(apiResult.Message);
        case HttpStatusCode.Forbidden:
            // A manual downgrade using the web interface is needed.
            break;
        case HttpStatusCode.InternalServerError:
            // Unspecified error - in this case, contact us. We will be able to help you more quickly if you sent the whole request which is causing the error.
            break;
        case HttpStatusCode.NotFound:
            // An entity was not found
            throw new InvalidOperationException("An entity was not found");
        case HttpStatusCode.OK:
            // Everything is awesome!
            break;
        case HttpStatusCode.ServiceUnavailable:
            // iDoklad API is down due to maintenance
            break;
        case HttpStatusCode.TooManyRequests:
            throw new InvalidOperationException("slow down");
        default:
            break;
    }
};

context.ApiResultHandler = handleApiResult;

// The handler will be called and if issued invoice with given Id doesn't exist, it will throw InvalidOperationException
// and you can catch it conveniently somewhere else in your code
var issuedInvoiceResult = await api.IssuedInvoiceClient.Detail(123456789).GetAsync();

// Separate handler is for ApiBatchResult, but works the same
Action<ApiBatchResult> handleBatchResult = (ApiBatchResult batchResult) => { ... };
context.ApiBatchResultHandler = handleBatchResult;
```

### 4. Filtering and paging

```csharp
// When retrieving list of entities, we can specify filter which applies inside iDoklad and reduces amount of data transferred.
// Expression used in Filter method allows usage only of those properties which can be filtered on server-side, it depends on
// entity type. The same applies to properties used in Sort method.
var list = api.ContactClient
    .List()
    .Filter(c => c.CompanyName.Contains("company"))
    .Filter(c => c.DateLastChange.IsGreaterThan(DateTime.UtcNow.AddMinutes(-10)))
    .FilterType(FilterType.And)
    .Sort(c => c.Id.Asc())
    .PageSize(100)
    .Page(1)
    .Get();

// Get with selector function calls that function to data returned from API.
// Less data is transferred between client and server - only properties used in expression.
// Following selector expression uses properties of nested objects - these objects have to be included by using Include method.
var detail = api.ContactClient
    .Detail(contactId)
    .Include(c => c.Bank, c => c.Country.Currency)
    .Get(c => new
    {
        CompanyName = c.CompanyName.ToUpper(CultureInfo.InvariantCulture),
        Currency = c.Country != null && c.Country.Currency != null ? c.Country.Currency.Name : string.Empty,
        Bank = c.Bank != null ? c.Bank.Name : string.Empty,
        Name = c.Firstname + " " + c.Surname,
        Address = $"{c.Street} {c.City} {c.PostalCode}",
        Discount = c.CompanyName.Length > 10 ? 10.0m : c.DiscountPercentage
    });
```

### 5. Additional examples

More examples can be found in test application **IdokladSdk.NetCore.TestApp**.
