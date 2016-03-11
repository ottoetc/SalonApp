# Hair Salon App_

#### _A basic hair salon web app, 3/10/2016_

#### By _**Nathan Otto**_

## Description

_This is a hair salon app that lists stylists and their clients. It is written in C# using the Nancy framework and Razor Views._

## Setup/Installation Requirements

* _Using Windows install Mono and make sure your .NET frameworks are up to date_
* _Download or clone the project folder from github_
* _In Powershell enter_ ```sqlcmd -S "(localdb)\mssqllocaldb"```
* _Enter the following commands to create the database_
```
CREATE DATABASE hair_salon;
GO
USE hair_salon;
GO
CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);
GO
```

* _Navigate to the project folder in Powershell and run "dnu restore"_
* _Run "dnx kestrel" to launch the local server_
* _In your web browser navigate to "localhost:5004"_

## Support and contact details

_Source code is [here](https://github.com/ottoetc/SalonApp) on Github_

## Technologies Used

_This project is built in C# using the Nancy web framework, Microsoft SQL database, and Razor Views syntax._

### License

_The MIT License (MIT)_

_Copyright (c) 2016 Nathan Otto_

_Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:_

_The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software._

_THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE._
