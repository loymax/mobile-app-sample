using System;
using CoreAnimation;
using CoreGraphics;
using Loymax.Core.iOS.Extensions;
using Loymax.Core.iOS.Implements;
using UIKit;

namespace MobileAppSample.iOS.Views
{

    public class MenuHeaderView : UIView
    {
        private bool? isAuth;

        public MenuHeaderView()
        {
            Initialize();
        }

        public MenuHeaderView(CGRect frame) : base(frame)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.SetStyle("lmx_BaseMenuHeaderView", target =>
            {
                target.BackgroundColor = this.ThemeManager().Colors.TintColor;
                target.Layer.ShadowOffset = new CGSize(0, 2);
                target.Layer.ShadowRadius = 2f;
                target.Layer.ShadowOpacity = 0.24f;
                target.Layer.ShadowColor = this.ThemeManager().Colors.TintColor.CGColor;
            });
            ConfigureAuthView();
            ConfigureNoAuthView();
            ConfigureLanguageView();

            AddSubviews(AuthContainerView, NoAuthContainerView, LanguageContainerView);

            AuthContainerView.SetFillYContraintTo(this, 16);
            AuthContainerView.SetLeftContraintTo(this, 16);
            AuthContainerView.SetRightContraintTo(this, 48);
            NoAuthContainerView.SetFillContraintTo(this, 16);
            LanguageContainerView.SetFillYContraintTo(this, 16);
            LanguageContainerView.SetLeftContraintTo(this, 16);
            LanguageContainerView.SetRightContraintTo(this, (float)UIScreen.MainScreen.Bounds.Width * 0.19f);

            SetNeedsUpdateConstraints();
            LayoutIfNeeded();

            AuthContainerView.Hidden = NoAuthContainerView.Hidden = true;
        }

        public UILabel UsernameLabel { get; set; } = new UILabel { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel BalanceLabel { get; set; } = new UILabel { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIImageView BrandLogo { get; set; } = new UIImageView { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel BrandLabel { get; set; } = new UILabel { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel AnonymBalanceLabel { get; set; } = new UILabel { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIImageView AvatarImageView { get; set; } = new UIImageView { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIView AuthContainerView { get; set; } = new UIView { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIView NoAuthContainerView { get; set; } = new UIView { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIView LanguageContainerView { get; set; } = new UIView { TranslatesAutoresizingMaskIntoConstraints = false };

        public UIImageView LanguageImageView { get; set; } = new UIImageView { TranslatesAutoresizingMaskIntoConstraints = false };

        public UILabel LanguageLabel { get; set; } = new UILabel { TranslatesAutoresizingMaskIntoConstraints = false };
        public bool IsAuth
        {
            get => isAuth ?? false;
            set => SetIsAuth(value);
        }

        protected virtual void ConfigureAuthView()
        {
            var horStackView = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Distribution = UIStackViewDistribution.Fill,
                Axis = UILayoutConstraintAxis.Horizontal,
                Alignment = UIStackViewAlignment.Center,
                Spacing = 16,
                LayoutMargins = new UIEdgeInsets(16, 0, 16, 16),
                LayoutMarginsRelativeArrangement = true
            };

            var vertStackView = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Distribution = UIStackViewDistribution.EqualSpacing,
                Axis = UILayoutConstraintAxis.Vertical,
                Alignment = UIStackViewAlignment.Fill,
                Spacing = 8
            };

            UsernameLabel.Font = this.ThemeManager().TextStyle.PreferredHeadline;
            UsernameLabel.TextColor = UIColor.White;
            UsernameLabel.Lines = 2;
            UsernameLabel.LineBreakMode = UILineBreakMode.TailTruncation;

            BalanceLabel.Font = this.ThemeManager().TextStyle.PreferredSubhead;
            BalanceLabel.TextColor = UIColor.White;

            horStackView.AddArrangedSubview(AvatarImageView);
            horStackView.AddArrangedSubview(UsernameLabel);

            vertStackView.AddArrangedSubview(horStackView);
            vertStackView.AddArrangedSubview(BalanceLabel);

            AvatarImageView.SetWidthContraint(64);
            AvatarImageView.SetAspectRatioContraint(1, 1);

            AuthContainerView.AddSubview(vertStackView);

            var isIphoneX = Math.Max(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height) >= 812.0f;

            vertStackView.SetFillXContraintTo(AuthContainerView);
            vertStackView.SetBottomContraintTo(AuthContainerView, 0, NSLayoutRelation.GreaterThanOrEqual);

            AuthContainerView.AddConstraint(
                NSLayoutConstraint.Create(vertStackView, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, AuthContainerView, NSLayoutAttribute.CenterY, 1, isIphoneX ? 7 : 0)
            );
        }

        protected virtual void ConfigureNoAuthView()
        {
            BrandLogo.ContentMode = UIViewContentMode.ScaleAspectFit;
            BrandLogo.SetStyle("lmx_BaseMenuHeaderView_BrandLogo", ImagePlaceholderProvider.Instance.SetPlaceholderImage);

            var isIphoneX = Math.Max(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height) >= 812.0f;

            AnonymBalanceLabel.Font = this.ThemeManager().TextStyle.PreferredSubhead;
            AnonymBalanceLabel.TextColor = UIColor.White;

            var stackView = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Distribution = UIStackViewDistribution.Fill,
                Axis = UILayoutConstraintAxis.Vertical,
                Alignment = UIStackViewAlignment.Leading,
                Spacing = 8
            };

            stackView.AddArrangedSubview(BrandLogo);
            stackView.AddArrangedSubview(AnonymBalanceLabel);

            NoAuthContainerView.AddSubview(stackView);

            stackView.SetFillXContraintTo(NoAuthContainerView);
            stackView.SetBottomContraintTo(NoAuthContainerView, 0, NSLayoutRelation.GreaterThanOrEqual);
            stackView.SetRightContraintTo(NoAuthContainerView, (float)UIScreen.MainScreen.Bounds.Width * 0.169f + 12, NSLayoutRelation.Equal);
            stackView.SetLeftContraintTo(NoAuthContainerView, 5, NSLayoutRelation.Equal);

            NoAuthContainerView.AddConstraint(
                NSLayoutConstraint.Create(stackView, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, NoAuthContainerView, NSLayoutAttribute.CenterY, 1, isIphoneX ? 7 : 0)
            );
        }

        protected virtual void ConfigureLanguageView()
        {
            var color = UIColor.FromRGBA(255, 255, 255, 120);
            LanguageLabel.SetStyle("lmx_BaseMenuHeaderView_LanguageLabel", target =>
            {
                target.TextColor = color;
            });

            LanguageImageView.SetStyle("lmx_BaseMenuHeaderView_LanguageImageView", target =>
            {
                target.TintColor = color;
                target.Image = UIImage.FromBundle("ic_menu_language")?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            });

            var stackView = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Distribution = UIStackViewDistribution.Fill,
                Axis = UILayoutConstraintAxis.Horizontal,
                Alignment = UIStackViewAlignment.Trailing,
                Spacing = 8
            };

            stackView.AddArrangedSubview(LanguageImageView);
            stackView.AddArrangedSubview(LanguageLabel);

            LanguageContainerView.AddSubview(stackView);

            var isIphoneX = Math.Max(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height) >= 812.0f;

            stackView.SetTopContraintTo(LanguageContainerView, isIphoneX ? 30 : 10, NSLayoutRelation.Equal);
            LanguageContainerView.AddConstraint(
                NSLayoutConstraint.Create(stackView, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, LanguageContainerView, NSLayoutAttribute.Trailing, 1, isIphoneX ? 7 : 0)
            );
        }

        private void SetIsAuth(bool value)
        {
            if (isAuth == value)
                return;

            var isAnimated = isAuth.HasValue;
            isAuth = value;
            var fromView = value ? NoAuthContainerView : AuthContainerView;
            var toView = value ? AuthContainerView : NoAuthContainerView;
            if (isAnimated)
            {
                toView.Alpha = 0;
                toView.Hidden = false;
                AnimateNotify(CATransaction.AnimationDuration, () =>
                {
                    fromView.Alpha = 0;
                    toView.Alpha = 1;
                }, finished =>
                {
                    fromView.Hidden = true;
                    toView.Hidden = false;
                });
            }
            else
            {
                fromView.Hidden = true;
                toView.Hidden = false;
            }
        }
    }
}
