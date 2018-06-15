# DiModelBindingExample
Dependency injection example for aspnet core (2.1) Web API action parameters using a custom ContractResolver.

If you need an action parameter to be provided by the DI-container (the ServiceProvider in vanilla aspnet core), you can add the attribute `[FromServices]` like so:
```csharp
public async Task<ActionResult<SomeResult>> AddSomething([FromServices] AddSomethingCommand)
```
(https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-2.1)

The downside of this is that regular model binding doesn't take place after this. So, anything that's been added to the request body doesn't get bound to `AddSomethingCommand`.

I've tried to use a custom ModelBinder to get the job done, but was unsuccesful. The following SO question kept me busy quite some time: https://stackoverflow.com/questions/35616035/mvc-6-custom-model-binder-with-dependency-injection

In the end, https://www.newtonsoft.com/json/help/html/DeserializeWithDependencyInjection.htm led me to the following solution, which this repo is the result of.

By overriding `CreateObjectContract` of `CamelCasePropertyNamesContractResolver` (any other `ContractResolver` can be used), 
this example manages to get an instance from the aspnet core DI-container, after which normal model binding takes place.



Helpful docs / blogposts / SO links:

https://www.newtonsoft.com/json/help/html/DeserializeWithDependencyInjection.htm
http://www.dotnetcurry.com/aspnet-mvc/1368/aspnet-core-mvc-custom-model-binding
http://www.dotnet-programming.com/post/2017/03/17/Custom-Model-Binding-in-Aspnet-Core-2-Model-Binding-Interfaces.aspx
https://stackoverflow.com/questions/35616035/mvc-6-custom-model-binder-with-dependency-injection
