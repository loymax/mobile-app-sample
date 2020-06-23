using Loymax.Core.Enums;
using Loymax.Core.Providers.Interfaces;
using Loymax.Core.Services.Interfaces;
using Loymax.Core.ViewModels.Elements;
using Loymax.Module.Profile.ViewModels;
using MvvmCross.Commands;


namespace MobileAppSample.Core.ViewModels
{
    public class NewProfileViewModel : ProfileViewModel
    {
        public NewProfileViewModel(ICurrentUserContext userContext, IUserProvider userProvider)
            : base(userContext, userProvider) { }

        protected override void ReloadSettings()
        {
            base.ReloadSettings();

            var newItem = new CellElement
            {
                Text = this["NewViewModel.Title"],
                ImageModel = "ic_new",
                Type = CellElementType.SingleCenterLine,
                Command = new MvxAsyncCommand(() => NavigationService.Navigate<NewViewModel>())
            };

            Items.Add(newItem);
        }
    }
}
