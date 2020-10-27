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

namespace MobileAppSample.Droid.Views
{
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Loymax.Core.Droid.Custom.Adapters;
    using Loymax.Core.Droid.ViewModels;
    using Loymax.Core.Droid.Views;
    using MvvmCross.Binding.BindingContext;
    using MobileAppSample.Core.ViewModels;
    using MvvmCross.ViewModels;
    using MvvmCross.Platforms.Android.Presenters.Attributes;
    using Google.Android.Material.Navigation;

    [MvxViewFor(typeof(MenuViewModel))]
    [MvxFragmentPresentation(typeof(MainMenuFragmentHostViewModel), Resource.Id.main_menuFragment)]
    [Register(nameof(MenuFragment))]
    public class MenuFragment : BaseFragment<MenuViewModel>
    {
        private NavigationViewAdapter navViewAdapter;

        protected override int FragmentId => Resource.Layout.menu_view;

        public override string Title { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var navigationView = base.OnCreateView(inflater, container, savedInstanceState) as NavigationView;
            if (navigationView == null)
            {
                return null;
            }

            this.navViewAdapter = new NavigationViewAdapter(navigationView);
            navigationView.SetNavigationItemSelectedListener(this.navViewAdapter);
            var set = this.CreateBindingSet<MenuFragment, MenuViewModel>();
            set.Bind(this.navViewAdapter).For(v => v.MenuItems).To(vm => vm.Items);
            set.Bind(this.navViewAdapter).For(v => v.SelectedMenuItemCommand).To(vm => vm.ItemClickCommand);
            set.Apply();

            return navigationView;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            if (this.navViewAdapter == null)
            {
                return;
            }

            this.navViewAdapter.Dispose();
            this.navViewAdapter = null;
        }
    }
}