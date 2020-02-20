/* Copyright (c) 2011-2019, Loymax (https://loymax.ru)
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

namespace MobileAppSample.Droid
{
    using Loymax.Core;
    using Loymax.Core.Droid;
    using Loymax.Core.Modules;
    using Loymax.Core.Providers.Interfaces;
    using MobileAppSample.Core;
    using MvvmCross;
    using System.Globalization;

    [Android.Runtime.Preserve(AllMembers = true)]
    public class Setup : BaseDroidSetup
    {
        protected override App CreateLxApp()
        {
            return new CoreApp();
        }

        protected override void AddPlatformModules(ILxLoaderModuleRegistry registry)
        {
            base.AddPlatformModules(registry);
            registry.Register<Loymax.Module.Merchants.Droid.MerchantsDroidModule>();
            registry.Register<Loymax.Module.ShoppingList.Droid.ShoppingListDroidModule>();
            registry.Register<Loymax.Module.Notifications.Droid.NotificationsDroidModule>();
            registry.Register<Loymax.Module.PurchaseHistory.Droid.PurchaseHistoryDroidModule>();
            registry.Register<Loymax.Module.SignIn.Droid.SignInDroidModule>();
            registry.Register<Loymax.Module.SignUp.Droid.SignUpDroidModule>();
            registry.Register<Loymax.Module.ResetPassword.Droid.ResetPasswordDroidModule>();
            registry.Register<Loymax.Module.Offers.Droid.OffersDroidModule>();
            registry.Register<Loymax.Module.Profile.Droid.ProfileDroidModule>();
            registry.Register<Loymax.Module.SupportService.Droid.SupportServiceDroidModule>();
            registry.Register<Loymax.Module.AboutApp.Droid.AboutAppDroidModule>();
        }

        protected override CultureInfo CurrentCultureInfo()
        {
            if (Mvx.IoCProvider.TryResolve(out ILocalizationProvider localization))
                return localization.CurrentCultureInfo;

            return CultureInfo.CurrentCulture;
        }
    }
}