namespace MobileAppSample.Droid
{
    using Loymax.Core;
    using Loymax.Core.Droid;
    using Loymax.Core.Modules;
    using MobileAppSample.Core;

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
    }
}