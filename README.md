# BoldSign API CSharp demo examples
Demostrates how to use BoldSign signing service. This sample uses ASP.NET Core web app.

[![NuGet Version][nuget badge]][nuget link]
[![NuGet Downloads][nuget downloads badge]][nuget downloads link]
[![API Demo][api demo badge]][api demo link]

## Scenarios covered

This repository includes the below list of code examples using the BoldSign APIs:

- [Send document for signing](/BoldSignDemos/Pages/CreateDocument/)
- [List and get detailed information of the documents](/BoldSignDemos/Pages/ListDocument/)
- [Send document from template](/BoldSignDemos/Pages/TemplateDocument/)
- [Embed signing process within your app](/BoldSignDemos/Pages/EmbeddedSign/)
- [Redirect to signing page from your app](/BoldSignDemos/Pages/EmbeddedSignWithForm/)

## Prerequisites
1.	Signup for [BoldSign trial](https://account.boldsign.com/signup?planId=101)
2.	Install BoldSign API’s NuGet package with the following command.

```csharp
dotnet add package BoldSign.Api
```
3.	Acquire needed BoldSign app credentials from here. [Authentication - Help Center - BoldSign](https://www.boldsign.com/help/api/general/authentication/#basic-authentication)
4.	Now you have all the prerequisites ready to start embedding BoldSign API.


## Steps to run samples

1. Open the Startup.cs file, and add your API key acquired from the BoldSign Web App in the ApiClient, by replacing the "***APIKey***". 
2. To run the [Send document from template](/BoldSignDemos/Pages/TemplateDocument/) sample, create a template from the web app with text field by naming SignerName, and SignerEmail. Add the copied template ID, in the sample template ID text box. 
3. To run the [Embed signing process within your app](/BoldSignDemos/Pages/EmbeddedSign/), and [Redirect to signing page from your app](/BoldSignDemos/Pages/EmbeddedSignWithForm/) sample, create a template from the web app with text field by naming SignerName, SignerAddress, SignerState, SignerPostalCode. Copy the template ID from the web app once the template has been created. Add the copied template ID, in the sample template ID text box. 

## Useful Resources
- [Send document from template by filling existing fields](https://www.boldsign.com/help/api/template/send-document-to-sign-using-template/#send-document-from-template-by-filling-existing-fields)
- [Send document for sign](https://www.boldsign.com/help/api/document/send-document-for-sign/)
- [API Reference Link](https://api.boldsign.com/swagger/index.html)

### Contact Us
Any feedback or queries? Please feel free to [contact our support team](https://www.boldsign.com/contact-us/) or mail to support@boldsign.com.

[api demo link]: https://www.boldsign.com/api-demo/
[api demo badge]: https://img.shields.io/badge/-API%20Demo-blue

[nuget link]: https://www.nuget.org/packages/BoldSign.Api/
[nuget badge]: https://img.shields.io/badge/nuget-v2.0.6-orange

[nuget downloads link]: https://www.nuget.org/packages/BoldSign.Api/
[nuget downloads badge]: https://img.shields.io/badge/downloads-2.5k%2B-brightgreen
