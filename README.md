# VehicleSignal.Backend


# Getting Started:
To clone and run this application, you'll need Git and Visual Stuido installed on your computer. From your command line:

# Clone these repository
- $ git clone https://github.com/hasanfcis/VehicleSignal.Backend.git

Open solution file "VehicleSignals.sln" using Visual Studio.

# Prerequisites:
- Visual Studio 2017
- SQL Server 2016

# Deployment
- Once you run the project that database will be created with the provieded data sent or run update-database command from Package Manager Console. 
- Build and run "VehicleSignal.Web.API" project which will start API service, and it's documented and testable via swagger throw this url http://localhost:2193/swagger/.
If you would like to change the web API port please go to VehicleSignal.Web.API project then under Properties open launchSettings.json
and change the set the port you want.
- Build and run "VehicleSignalRandomGenerator" project which will generate random car pings with the random status using API service,     and you can change the API URL from the appsettings json file. 
- I used th travis-ci for the continous integration purpose (build and run unit tests).

# Built With:
- Visual Studio 2017.
- SQL Server 2016.
- travis-ci.
# Technologies Used:
- .NetCore
- MVC Web API
- Entity Framework
- AutoMapper
- Moq
- xUnit.net
- Fluent Assertion

# Architecture
![vehiclesignalarchitecture](https://user-images.githubusercontent.com/9886479/38573826-7d8721c0-3cf7-11e8-9681-9279a45a9858.jpg)
