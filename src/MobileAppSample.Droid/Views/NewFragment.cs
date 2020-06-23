using Android.Runtime;
using Loymax.Core.Droid.ViewModels;
using Loymax.Core.Droid.Views;
using MobileAppSample.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.ViewModels;

namespace MobileAppSample.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainMenuFragmentHostViewModel), FragmentHostViewModel.FragmentId)]
    public class NewFragment : BaseFragment<NewViewModel>
    {
        protected override int FragmentId => Resource.Layout.new_view;
    }
}