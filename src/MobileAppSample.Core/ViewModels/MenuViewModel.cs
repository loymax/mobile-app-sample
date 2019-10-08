namespace MobileAppSample.Core.ViewModels
{
    using Loymax.Core.Services.Interfaces;
    using Loymax.Core.ViewModels.Base;
    using MvvmCross.Plugin.Messenger;

    public class MenuViewModel : BaseMenuViewModel
    {
        public MenuViewModel(IMvxMessenger messenger, ICurrentUserContext userContext) : base(messenger, userContext)
        {
        }
    }
}