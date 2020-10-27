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

namespace MobileAppSample.iOS.Views
{
    using System;
    using CoreGraphics;
    using Loymax.Core.Converters;
    using Loymax.Core.iOS.Custom.Bindings;
    using Loymax.Core.iOS.Custom.Converters;
    using Loymax.Core.iOS.Extensions;
    using Loymax.Core.iOS.Views;
    using Loymax.Core.ViewModels.Base;
    using MobileAppSample.Core.ViewModels;
    using MvvmCross.Binding.BindingContext;
    using MvvmCross.Platforms.Ios.Binding;
    using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
    using MvvmCross.ViewModels;
    using UIKit;

    [MvxViewFor(typeof(MenuViewModel))]
    public class MenuView : BaseMenuView<BaseMenuViewModel>
    {
        protected override UIView CreateHeaderView(UITableView tableView, ref MvxFluentBindingDescriptionSet<BaseMenuView<BaseMenuViewModel>, BaseMenuViewModel> set)
        {
            var headerView = new MenuHeaderView(new CGRect(0f, 0f, (float)UIScreen.MainScreen.Bounds.Width, Math.Min(180, 0.3f * (float)View.Bounds.Height)));
            headerView.SetHeightContraint(Math.Min(180, 0.3f * (float)View.Bounds.Height), NSLayoutRelation.Equal);

            ImageViewAvatarTargetBinding.DefaultColor = this.ThemeManager().Colors.AccentColor;
            set.Bind(headerView).For(v => v.IsAuth).To(vm => vm.IsAuth);
            set.Bind(headerView.UsernameLabel).To(vm => vm.CurrentUser.Username);
            set.Bind(headerView.BalanceLabel).To(vm => vm.CurrentUser.BalanceShortInfo).WithConversion(BalanceShortInfoConverter.Key);
            set.Bind(headerView.AvatarImageView).For(ImageViewAvatarTargetBinding.Key).To(vm => vm.CurrentUser.Username);
            set.Bind(headerView.AnonymBalanceLabel).To(vm => vm.CurrentUser.BalanceShortInfo).WithConversion(BalanceShortInfoConverter.Key);
            set.Bind(headerView.AnonymBalanceLabel).For(v => v.Hidden).To(vm => vm.HaveIsVirtualCard).WithConversion(InvertedBooleanConverter.Key);
            set.Bind(headerView.LanguageContainerView).For(v => v.Hidden).To(vm => vm.IsLocalization).WithConversion(InvertedBooleanConverter.Key);
            set.Bind(headerView.LanguageImageView).For(v => v.BindTap()).To(vm => vm.ChangeLocalizationCommand);
            set.Bind(headerView.LanguageLabel.Tap()).For(v => v.Command).To(vm => vm.ChangeLocalizationCommand);
            set.Bind(headerView.LanguageLabel).To(vm => vm.CurrentCulture);
            return headerView;
        }
    }
}