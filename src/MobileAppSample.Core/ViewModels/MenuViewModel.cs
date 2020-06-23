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

namespace MobileAppSample.Core.ViewModels
{
    using System.Collections.Generic;
    using Loymax.Core;
    using Loymax.Core.Providers.Interfaces;
    using Loymax.Core.Services.Interfaces;
    using Loymax.Core.ViewModels.Base;
    using Loymax.Core.ViewModels.Elements;
    using MvvmCross.Commands;
    using MvvmCross.Plugin.Messenger;

    public class MenuViewModel : BaseMenuViewModel
    {
        public MenuViewModel(IMvxMessenger messenger, ICurrentUserContext userContext, ILocalizationProvider localizationProvider) : base(messenger, userContext, localizationProvider)
        {
        }

        //TODO NewModule
        /*
        protected override IList<MenuCellElement> GetCurrentItems()
        {
            var items = base.GetCurrentItems();
            items?.Add(NewCellElement);

            return items;
        }

        private MenuCellElement NewCellElement => new MenuCellElement
        {
            Text = Localize.GetText("NewViewModel.Title"),
            ImageModel = "ic_new",
            Command = new MvxAsyncCommand(ShowMenuItem<NewViewModel>)
        };
        */
    }
}
 