namespace MobileAppSample.iOS.Views
{
    using Loymax.Core.iOS.Views;
    using Loymax.Core.ViewModels.Base;
    using MobileAppSample.Core.ViewModels;
    using MvvmCross.ViewModels;

    [MvxViewFor(typeof(MenuViewModel))]
    public class MenuView : BaseMenuView<BaseMenuViewModel>
    {
    }
}