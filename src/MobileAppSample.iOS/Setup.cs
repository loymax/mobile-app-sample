/* Copyright (c) 2011-2020, Loymax (https://loymax.ru)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.*/

namespace MobileAppSample.iOS
{
    using GoogleAnalytics.iOS;
    using Loymax.Core;
    using Loymax.Core.iOS;
    using Loymax.Core.iOS.Extensions;
    using Loymax.Core.iOS.Implements;
    using Loymax.Core.iOS.Style.Interfaces;
    using Loymax.Core.Modules;
    using Loymax.Core.Providers.Interfaces;
    using Loymax.Support.Style.iOS.Managers;
    using Loymax.Support.Style.iOS.Settings;
    using MobileAppSample.Core;
    using MvvmCross;
    using MvvmCross.Logging;
    using MvvmCross.Platforms.Ios.Core;
    using MvvmCross.Platforms.Ios.Presenters;
    using System.Collections.Generic;
    using System.Globalization;
    using UIKit;

    public class Setup : BaseIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
        {
        }

        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        protected override App CreateLxApp() => new CoreApp();

        protected override IThemeManager CreateThemeManager()
        {
            var fileSettings = new RenderSettings.FileSettings("style.less");
            var settings = new RenderSettings(new List<RenderSettings.FileSettings>
            {
                fileSettings
            })
            {
                ThemeViewControllers = new ThemeManager.ThemeViewControllers(),
                ConfigureAppearance = ThemeManager.SelfConfigureAppearance
            };

#if DEBUG
            if (!string.IsNullOrEmpty(Application.StylePath) && DeviceExtension.IsEmulator)
            {
                var realtimeFileSettings = new RenderSettings.FileSettings(Application.StylePath)
                {
                    RealtimeUpdateStyle = true
                };

                settings.FilesSettings.Add(realtimeFileSettings);
            }
#endif

            LxThemeManager.Init(this.Window, settings);

            return LxThemeManager.Instance;
        }

        protected override CultureInfo CurrentCultureInfo()
        {
            if (Mvx.IoCProvider.TryResolve(out ILocalizationProvider localization))
                return localization.CurrentCultureInfo;

            return CultureInfo.CurrentCulture;
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            Mvx.IoCProvider.CallbackWhenRegistered<IAnalyticsProvider>(() =>
            {
                var provider = Mvx.IoCProvider.Resolve<IAnalyticsProvider>();
                provider.RegisterListener<GoogleAnalyticsListener>();
            });
        }

        protected override IMvxLogProvider CreateLogProvider()
        {
#if !RELEASE
            return new LogProvider();
#else
            return base.CreateLogProvider();
#endif
        }

        protected override void AddPlatformModules(ILxLoaderModuleRegistry registry)
        {
            base.AddPlatformModules(registry);
            registry.Register<Loymax.Module.Merchants.iOS.MerchantsIosModule>();
            registry.Register<Loymax.Module.ShoppingList.iOS.ShoppingListIosModule>();
            registry.Register<Loymax.Module.Notifications.iOS.NotificationsIosModule>();
            registry.Register<Loymax.Module.PurchaseHistory.iOS.PurchaseHistoryIosModule>();
            registry.Register<Loymax.Module.SignIn.iOS.SignInIosModule>();
            registry.Register<Loymax.Module.SignUp.iOS.SignUpIosModule>();
            registry.Register<Loymax.Module.ResetPassword.iOS.ResetPasswordIosModule>();
            registry.Register<Loymax.Module.Offers.iOS.OffersIosModule>();
            registry.Register<Loymax.Module.Profile.iOS.ProfileIosModule>();
            registry.Register<Loymax.Module.SupportService.iOS.SupportServiceIosModule>();
            registry.Register<Loymax.Module.AboutApp.iOS.AboutAppIosModule>();
#if !RELEASE
            registry.Register<Loymax.Module.ClientSettings.iOS.ClientSettingsIosModule>();
#endif
        }
    }
}