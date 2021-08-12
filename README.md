The repository includes code examples for the BoldSign Api's [SendDocument](https://www.boldsign.com/help/api/document/send-document-for-sign/#send-document), [GetProperties](https://www.boldsign.com/help/api/document/get-document-properties/), [ListDocuments](https://www.boldsign.com/help/api/document/list-documents/), [GetEmbeddedSignLink](https://www.boldsign.com/help/api/document/get-embed-signing-link-for-a-signer/) and [SendForSignFromTemplate](https://www.boldsign.com/help/api/template/send-document-to-sign-using-template/)

Introduction

The BoldSign API allows you to send documents to collect e-signatures from within your app. BoldSign has a necessary set of APIs that give you complete control over documents and properties.

Prerequisites

1. To work with BoldSign API, you need an enterprise or trial plan.
https://www.boldsign.com/pricing/

2. You should be an account admin to create a developer and configuring webhooks.

Steps to run :

1. We need to create ClientID and ClientSecret in our BoldSign application, explained in this [link](https://www.boldsign.com/help/api/general/preparing-your-application/#acquire-app-credentials),
2. Add ClientID & ClientSecret in your system enviornemnt variables,

```cs

//client id for get access token
string clientId = Environment.GetEnvironmentVariable("ClientID");

//client secret for get access token
string clientSecret = Environment.GetEnvironmentVariable("ClientSecret");
                
```
4.  For Template document and EmbeddedSign sample you need to [create template](https://www.boldsign.com/help/getting-started/creating-templates/) with the following scenario's

    1. For the Template document sample, create a template with Name and Email form fields, and also name should be SignerName and SignerEmail.
    2. For Embedded Sign sample, create a template with Name, Address, State, PostalCode form fields and also name should be SignerName, SignerAddress, SignerState, SignerPostalCode 

 Please refer to this [link]( https://www.boldsign.com/help/api/template/send-document-to-sign-using-template/#send-document-from-template-by-filling-existing-fields) for adding form fields with names.