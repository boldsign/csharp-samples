The repository will contain Bold Sign API demos samples.

Steps to run :
1. [Prerequisites](https://www.boldsign.com/help/api/general/preparing-your-application/#prerequisites)

2. We need to create ClientID and ClientSecret in our BoldSign application, explained in this [link](https://www.boldsign.com/help/api/general/preparing-your-application/#acquire-app-credentials),
3. Add ClientID & ClientSecret in your system enviornemnt variables,

```cs

using var request = new HttpRequestMessage()
{
    Content = encodedContent,
    Method = HttpMethod.Post,
    RequestUri = new Uri(Environment.GetEnvironmentVariable("RequestUri")),
};

//client id for get access token
string clientId = Environment.GetEnvironmentVariable("ClientID");

//client secret for get access token
string clientSecret = Environment.GetEnvironmentVariable("ClientSecret");
                
```
4.  For Template document and EmbeddedSign sample you need to [create template](https://www.boldsign.com/help/getting-started/creating-templates/) with the following scenario's

    1. For the Template document sample, create a template with Name and Email form fields, and also name should be SignerName and SignerEmail.
    2. For Embedded Sign sample, create a template with Name, Address, State, PostalCode form fields and also name should be SignerName, SignerAddress, SignerState, SignerPostalCode 

 Please refer to this [link]( https://www.boldsign.com/help/api/template/send-document-to-sign-using-template/#send-document-from-template-by-filling-existing-fields) for adding form fields with names.