# BoldSign API CSharp demo samples

This repository includes code examples for the BoldSign Api's [SendDocument](https://www.boldsign.com/help/api/document/send-document-for-sign/#send-document), [GetProperties](https://www.boldsign.com/help/api/document/get-document-properties/), [ListDocuments](https://www.boldsign.com/help/api/document/list-documents/), [GetEmbeddedSignLink](https://www.boldsign.com/help/api/document/get-embed-signing-link-for-a-signer/) and [SendForSignFromTemplate](https://www.boldsign.com/help/api/template/send-document-to-sign-using-template/)

## Introduction

The BoldSign API allows you to send documents to collect e-signatures from within your app. BoldSign has a necessary set of APIs that give you complete control over documents and properties.

### Install the package

dotnet add package BoldSign.Api
The other ways of installing a package are available here:
[Install and manage NuGet packages in Visual Studio](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio)

### Prerequisites:

1.	To work with BoldSign API, you need an enterprise or trial plan.

    https://www.boldsign.com/pricing/

2.	Create an OAuth application to enable API access by following the steps outlined here 
3.	Visual studio 2019 with ASP.NET package.

### Steps to run samples:

1.	Add ClientID & ClientSecret in your system environment variables.

```cs
//client id for get access token -->

string clientId = Environment.GetEnvironmentVariable("ClientID");

//client secret for get access token

string clientSecret = Environment.GetEnvironmentVariable("ClientSecret");

```
          
2.	For Template document and EmbeddedSign sample, you need to [create template](https://www.boldsign.com/help/getting-started/creating-templates/) with the following scenarios.

    a.	For the Template document sample, create a template with Name and Email form fields, and change name of the fields in respective field settings to SignerName and SignerEmail.

    b.	For Embedded Sign sample, create a template with Name, Address, State, PostalCode form fields and change name of the fields in respective field settings to SignerName, SignerAddress, SignerState, SignerPostalCode.
 
Please refer to this [link](https://www.boldsign.com/help/api/template/send-document-to-sign-using-template/#send-document-from-template-by-filling-existing-fields) for adding form fields with names.
