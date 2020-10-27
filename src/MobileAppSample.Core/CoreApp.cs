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

namespace MobileAppSample.Core
{
    using System;
    using Loymax.Core;
    using Loymax.Core.LocalStorage;
    using Loymax.Core.Modules;
    using Loymax.Core.Settings;
    using Loymax.Core.Settings.Client;
    using Loymax.Core.ViewModels.Locators;
    using Loymax.Core.ViewModels.Screens;
    using Loymax.Module.Profile.ViewModels;
    using MobileAppSample.Core.ViewModels;
    using MvvmCross;

    public class CoreApp : App
    {
        private ILocalStorage _localStorage;
        protected ILocalStorage LocalStorage => _localStorage ?? (_localStorage = Mvx.IoCProvider.Resolve<ILocalStorage>());

        public override Type MainViewModelType
        {
            get
            {
                var isFirstLaunch = LocalStorage.GetValueOrDefault(LocalizationViewModel.KEY, true);
                if ((AppSettings.Current.Environment?.Localization?.Enable ?? false)
                    && (AppSettings.Current.Environment?.Localization?.ViewLocalization ?? false)
                    && isFirstLaunch)
                    return typeof(LocalizationViewModel);
                return typeof(Loymax.Module.Offers.ViewModels.OffersViewModel);
            }
        }


        protected override IClientEnvironmentSettings CreateClientSettings()
        {
            return new ClientEnvironmentSettings(typeof(CoreApp).Assembly,
#if DEBUG
                BuildEnvironmentType.Development
#elif ADHOC
                BuildEnvironmentType.Staging
#else
                BuildEnvironmentType.Production
#endif
            );
        }

        public override void LoadModules(ILxModuleManager moduleManager)
        {
            base.LoadModules(moduleManager);
            moduleManager.EnsurePluginLoaded<Loymax.Module.Merchants.MerchantsModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.ShoppingList.ShoppingListModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.Notifications.NotificationsModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.PurchaseHistory.PurchaseHistoryModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.SignIn.SignInModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.SignUp.SignUpModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.ResetPassword.ResetPasswordModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.Offers.OffersModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.Profile.ProfileModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.SupportService.SupportServiceModule>();
            moduleManager.EnsurePluginLoaded<Loymax.Module.AboutApp.AboutAppModule>();
#if !RELEASE
            moduleManager.EnsurePluginLoaded<Loymax.Module.ClientSettings.ClientSettingsModule>();
#endif
        }

        protected override void ReplaceViewModels(IReplaceViewModelAdapter replaceViewModelAdapter)
        {
            base.ReplaceViewModels(replaceViewModelAdapter);
            //replaceViewModelAdapter.Replace(typeof(ProfileViewModel), typeof(NewProfileViewModel));
        }
    }
}