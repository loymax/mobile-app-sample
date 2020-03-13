<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![MIT License][license-shield]][license-url]

<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/loymax/mobile-app-sample">
    <img src="Images/logo.png" alt="Logo" width="160" height="57">
  </a>

  <h3 align="center">Mobile App Sample</h3>

  <p align="center">
    MobileAppSample – это стандартное приложение, сгенерированное конструктором мобильных приложений компании Loymax.
    <br />
    <a href="https://github.com/loymax/mobile-app-sample"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/loymax/mobile-app-sample">View Demo</a>
    ·
    <a href="https://github.com/loymax/mobile-app-sample/issues">Report Bug</a>
    ·
    <a href="https://github.com/loymax/mobile-app-sample/issues">Request Feature</a>
  </p>
</p>

*Read this in other languages: [English](README.md)*

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
* [Getting Started](#getting-started)
  * [Installation](#installation)
* [License](#license)
* [Contact](#contact)

<!-- ABOUT THE PROJECT -->
## About The Project

![Product Name Screen Shot][product-screenshot-1]
 <p align="center">
    MobileAppSample – шаблонное мобильное приложение компании Loymax.
 </p>

<!-- GETTING STARTED -->
## Getting Started

Для запуска локальной копии выполните следующие простые шаги.

### Installation
Для корректной работы приложения на платформе Android необходимо установить ключ 
```JS
const com.google.android.maps.v2.API_KEY;
```
1. Получить ключ [Link](https://developers.google.com/maps/documentation/android-sdk/get-api-key)
2. Полученный ключ необходимо разместить в поле Value :
```sh
MobileAppSample.Droid \ Properties \ AssemblyInfo.cs  
[assembly: MetaData("com.google.android.maps.v2.API_KEY", Value = "")] 
```

Если не удалось восстановить NuGet пакеты, укажите источник NuGet вручную.
```sh
https://repository.loymax.net/repository/nuget-ext/
```

Mobile App Sample поддерживает App center, для подключение которого необходимо:

1. Получить AppKey на [App Center](https://appcenter.ms) для Android и iOS
2. Добавить AppKey в место "required" для Android и iOS соответственно.
```sh
MobileAppSample.Core \ Config.yaml
HockeyApp: 
  AppKey:
    Android: "required"
    Ios: "required"
```

Visual Studio 2019 for Windows & Mac. 
* Xamarin - 16.3.0.274
* Xamarin.Android SDK - 10.0.0.43
* Xamarin.iOS SDK - 13.2.0.42

<!-- LICENSE -->
## License

Distributed under the Apache 2.0 License. See `LICENSE` for more information.

<!-- CONTACT -->
## Contact

[Loymax](https://loymax.io/en/)

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[license-shield]: https://img.shields.io/badge/License-Apache%202.0-blue.svg
[license-url]: https://github.com/loymax/mobile-app-sample/blob/master/LICENSE
[product-screenshot-1]: Images/screenshot_ru.png