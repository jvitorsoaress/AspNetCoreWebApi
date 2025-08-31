# Microsoft Learn Tutorial: Create a controller-based web API with ASP.NET Core

<small>By Tim Deschryver and Rick Anderson</small>

### Description
This repo was created for practicing based on the original documentation and save whatever I've learned here.

Feel free to reach out if you see something wrong or else.

### Getting Started

To run this project locally, follow the steps below:

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download) (8.x). Verify with:
  ```bash
  dotnet --version
  ```
  It should print something like 8.*.

### 1. Clone the repository

```bash
git clone https://github.com/jvitorsoaress/AspNetCoreWebApi.git
cd AspNetCoreWebApi
```

### 2. Trust the HTTPS development certificate

``` bash
dotnet dev-certs https --trust
```

### 3. Run the project

``` bash
dotnet run --launch-profile https
```

### 4. Find swagger
Use Ctrl+click on the HTTPS URL in the output to test the web app in a browser.
The default browser is launched to 
``` bash
https://localhost:<port>/swagger/index.html
```

So you have to append /swagger to the URL.


---
Link for the original documentation: https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
