# kkday-b2d-internagent

This project is a demonstration based on KKday B2D API version 4.0 (<a href="https://api-b2d.kkday.com/Redoc">link</a>), which is a free, white-label website that allows for all operations: search, product, package selection, booking (no payment required), and ordering. The code primarily consists of BootstrapVue and some ASP.NET Core 7.0, so JavaScript and object-oriented programming skills are required. Most of the core knowledge of the B2D API is located in the ~/Views/ directory, which contains several directories containing files with the .cshtml extension for easy manipulation, or you can directly read these files.

The PMDL(Product Model Definition Layer) will be presented and composite into whole product page. The purpose of BookingField (Order Model Definition Layer) is a conditon which satisfy to supplier operation, and this project shows you how to transform required fields into BookingModel for booking. We also show you inline BookingModel during you fill in information on Web page. 

You must be approved distributors(agents) on SIT environment fisrt, then to get a token key of API account through B2D website.

Support languages:
1. zh-TW (https://localhost:5001/zh-tw/) 
2. en-US (https://localhost:5001/en-us/)

Licensing
==============
InternAgent is open source under the MIT license and is free for commercial use. Partial images and CSS are kkday.com copyright

How to build
==============
1. Install <a href="https://visualstudio.microsoft.com/vs/whatsnew/">Visual Studio 2022</a> or <a href="https://code.visualstudio.com/docs/languages/dotnet">Visual Studio Code<a/> or <a href="https://www.jetbrains.com/rider/download/">JetBrains Rider</a>
2. ASP.Net Core 7.0 (or Above) requirement.
3. Copy "appsettings.json.template" to "appsettings.json".
4. Setup some properties (eg. 'AuthorToken') in "appsettings.json".
5. Open project and Run
