# Angular2 Template project
This is template of web project using angular2 as client application framework and asp.net core as http data service framework. The tamplate was based on channel 9 webcast [Building web apps powered by Angular 2.x using Visual Studio 2017](https://channel9.msdn.com/Events/Visual-Studio/Visual-Studio-2017-Launch/WEB-103) and article [Building Single Page Applications on ASP.NET Core with JavaScriptServices](https://blogs.msdn.microsoft.com/webdev/2017/02/14/building-single-page-applications-on-asp-net-core-with-javascriptservices/)


## Preparing environment

1. Install Visual Studio 2017 (any version)

2. Install SPA templates by running following command in CMD:

    dotnet new --install Microsoft.AspNetCore.SpaTemplates::*

## Initializing project

1. In VS2017 create an empty solution

2. Create web project directory inside solution directory by running following command in CMD:

    mkdir src
	cd src
	mkdir <project-name>.Web

3. Generate a new project by running following command in CMD:

	dotnet new angular

4. Restore .NET and NPM dependencies by running following command in CMD:

	dotnet restore
	npm install
	
(Re)open project in VS, build and run it. You should see angular application running in browser.

## Updating application

You can update application by following all the steps mentioned in webcast. However there are some small differences as of time of writing this readme.

- It seems SPA template is for Angular 2.x and webcast is done on Angular 4.x (e.g. template doesn't include 'angular2-universal' package).

	* It has some consequences (e.g. different code, when calling http service, using 'ORIGIN_URL' instead, see template fetch-data.ts).

- Template in webcast has 'app.module.ts' (btw. where 'angular2-universal' is imported) but my installed template has 'app.module.shared.ts' instead.

	* template doesn't define "providers" variable (you need to update app.module.client.ts and app.module.server.ts).

