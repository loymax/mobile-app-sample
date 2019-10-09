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