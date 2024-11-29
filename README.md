# kkday-b2d-internagent

This project is a demonstration based on KKday B2D API version 4.0 (<a href="https://api-b2d.kkday.com/Redoc">link</a>), which can be executed independently and provide actions: Search, Product, Package and Selection, Booking (no payment), Order. The code includes major BootstrapVue and portion DotNet 7.0, you need to have development skills in Javascript and object-oriented programming. Most kernel knowledge of B2D API is at ~/Views/, there has some directories and the file ext-name is .cshtml under it to let you easy to handle it, or you can read these files directly.

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
1. Install <a href="https://visualstudio.microsoft.com/vs/whatsnew/">Visual Studio 2022</a> or <a href="https://code.visualstudio.com/docs/languages/dotnet">Visual Studio Code<a/> with ASP.Net Core 7.0 (or Above).
2. Copy "appsettings.json.template" to "appsettings.json".
3. Setup some properties (eg. 'AuthorToken') in "appsettings.json".
4. Open project and Run
