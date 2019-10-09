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

namespace MobileAppSample.iOS
{
    using Loymax.Core.iOS.Style;
    using Loymax.Core.iOS.Style.Interfaces;
    using UIKit;

    public static class ThemeManager
    {
        public static void SelfConfigureAppearance(IThemeManager themeManager)
        {
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarStyle = UIBarStyle.Black;
            UINavigationBar.Appearance.BarTintColor = themeManager.Colors.TintColor;
            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.White
            };

            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0)) UISearchBar.Appearance.TintColor = UIColor.White;

            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
        }

        public class ThemeViewControllers : DefaultThemeViewControllers
        {
            public override void SetBarStyle(UINavigationController navController)
            {
                var navBar = navController?.NavigationBar;
                if (navBar != null)
                {
                    var attributes = new UIStringAttributes
                    {
                        ForegroundColor = UIColor.White
                    };

                    navBar.TitleTextAttributes = attributes;
                    navBar.Translucent = false;
                    navBar.BarStyle = UIBarStyle.Default;
                    navBar.TintColor = UIColor.White;
                }
            }
        }
    }
}

