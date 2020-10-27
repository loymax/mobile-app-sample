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

using Android.Runtime;
using Loymax.Core.Droid.ViewModels;
using Loymax.Core.Droid.Views;
using MobileAppSample.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.ViewModels;

namespace MobileAppSample.Droid.Views
{
    [MvxViewFor(typeof(NewViewModel))]
    [MvxFragmentPresentation(typeof(MainMenuFragmentHostViewModel), FragmentHostViewModel.FragmentId)]
    [Register(nameof(NewFragment))]
    public class NewFragment : BaseFragment<NewViewModel>
    {
        protected override int FragmentId => Resource.Layout.new_view;
    }
}