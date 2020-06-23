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
* [Adding a section to the side menu](#adding-a-section-to-the-side-menu)
* [Adding a new item to settings](#adding-a-new-item-to-settings)
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

## Adding a section to the side menu
1. Создать новую _ViewModel_ в _Core_, наследуется от _BaseViewModel_ или _MvxViewModel_
2. Создать новые _View_

  2.1. **Android** - новые view могут быть представлены _activity_ или _fragment_.
  В боковом меню используются только _fragments_, но при желании туда могут быть добавлены и _Activity_. _Fragments_ наследуется от _BaseFragment_ или _MvxFragment_. BaseFragment и _MvxFragment_ - шаблонные классы, использующие тип _VivewModel_ созданный на первом шаге.
  Для привязки Fragment к Activity используются атрибуты _MvxFragmentPresentation_ из _MvvmCross_. Имя host activity для меню _MainMenuFragmentHostViewModel_. Также необходимо указать _ID_ для фрагмента и в базовом классе необходимо переопределить свойство _FragmentID_. 

  ###### Пример:
  ```csharp
  [MvxFragmentPresentation(typeof(MainMenuFragmentHostViewModel), FragmentHostViewModel.FragmentId)]
  public class NewFragment : BaseFragment<NewViewModel>
  {
        protected override int FragmentId => Resource.Layout.new_view;
  }
  ```
  2.2. **iOS** – добавить новый View Controller
  При создании нового View Controller автоматически создаются: 
  _.cs, .designer.cs и .Xib_.
  Новый View Controller наследуется от _BaseViewController_ или _MvxViewController_. _BaseViewController_ и _MvxViewController_ - шаблонные классы, использующие тип ViewModel, созданный на первом шаге.

  ###### Пример:
  ```csharp
  [SidebarPresentation]
  public partial class NewView : BaseViewController<NewViewModel> 
  { }
  ```
3. Все элементы бокового меню представлены списком элементов _MenuCellElement_. Для добавление нового элемента в боковое меню необходимо в классе _Core.MenuViewModel_ переопределить метод _GetCurrentItems()_ из родительского класса _BaseMenuViewModel_ и добавить новый _MenuCellElement_.
        
  3.1. Создание _MenuCellElement_ 
  Класс _MenuCellElement_ имеет множество свойств и методов. 
  Рассмотрим основные свойства, которые необходимы для добавления в боковое меню: 
  * ***Text*** – название раздела.
  * ***ImageModel*** – названия ресурса, представленное строкой, название должно совпадать на _Android_ и _iOS_. 
  * ***Command*** – команда, которая будет вызвана при нажатии на элемент бокового меню. В команду обычно помещается шаблонный метод _ShowMenuItem_ с типом _ViewModel_, созданной на шаге 1. 

  ###### Пример:
  ```csharp
  var NewCellElement = new MenuCellElement
  {
        Text = Localize.GetText("NewViewModel.Title"),
        ImageModel = "ic_menu_new",
        Command = new MvxAsyncCommand(ShowMenuItem<NewViewModel>)
  };
  ```
 
  3.2. Экземпляр класса _MenuCellElement_ добавляется в возвращаемый список метода _GetCurrentItems()_.
  ###### Пример:
  ```csharp
  protected override IList<MenuCellElement> GetCurrentItems()
  {
        var items = base.GetCurrentItems();
        items?.Add(NewCellElement);
        return items;
  }
  ```


## Adding a new item to settings

1. Все элементы в настройках представлены списком элементов _CellElement_. Для добавление нового элемента необходимо:
   1. Создать класс _NewProfileViewModel_ наследуясь от _ProfileViewModel_
   1. Переопределим метод _ReloadSettings()_
   1. В методе _ReloadSettings()_ добавляем новый _CellElement_ в свойство _Items_
Рассмотрим основные свойства _CellElement_, которые необходимы для списка настроек:

  * ***Text*** – название раздела.
  * ***ImageModel*** – названия ресурса, представленное строкой, название должно совпадать на **Android** и **iOS**. 
  * ***Command*** – команда, которая будет вызвана при нажатии на элемент бокового меню.
  * ***Type*** – тип ячейки.
###### Пример:
```csharp
public class NewProfileViewModel : ProfileViewModel
{
    public NewProfileViewModel(ICurrentUserContext userContext, IUserProvider userProvider)
        : base(userContext, userProvider) { }

    protected override void ReloadSettings()
    {
        base.ReloadSettings();
        var newItem = new CellElement {
            Text = this["NewViewModel.Title"],
            ImageModel = "ic_new",
            Type = CellElementType.SingleCenterLine,
            Command = new MvxAsyncCommand(() => NavigationService.Navigate<NewViewModel>())
        };

        Items.Add(newItem);
    }
}
```
2. В классе _CoreApp_ заменить текущую  _ViewModel_  _ProfileViewModel_  на новую  _NewProfileViewModel_ в методе _ReplaceViewModels_.
###### Пример:
```csharp
protected override void ReplaceViewModels(IReplaceViewModelAdapter replaceViewModelAdapter)
{
    base.ReplaceViewModels(replaceViewModelAdapter);
    replaceViewModelAdapter.Replace(typeof(ProfileViewModel), typeof(NewProfileViewModel));
}
```

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