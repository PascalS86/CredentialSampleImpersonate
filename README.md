# CredentialSampleImpersonate

Contains a Caller Project and a Receiver Project.
Both projects are WebAPI MVC Projects, that use windows-authentication.

Both projects needs to be started

Language is CSharp


## Caller Project
Web.Config needs the following Tag:
<system.web>
  <identity impersonate="true" />
</system.web>

The follwing code snippet does the job:

            System.Security.Principal.WindowsImpersonationContext impersonationContext;
            impersonationContext =
                ((System.Security.Principal.WindowsIdentity)User.Identity).Impersonate();

            using (HttpClient client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                var result = await client.GetAsync(["receiverurl/api/values"]);


            }
            impersonationContext.Undo();
            
## Receiver Project

Values Controller needs Authorization

