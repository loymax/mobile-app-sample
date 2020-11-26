using System;
using Binding;
using UIKit;

namespace Xamarin.SingleView
{
    public partial class ViewController : UIViewController
    {
        UIViewController NewViewController;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var proxy = new SwiftFrameworkProxy();
 
            HelloWorldLabel.Text = $"Value from Framework Swift - {proxy.Value}";

            NewViewController = proxy.ViewController;
            NextButton.TouchUpInside += HandleTouchUpInsideWithWeakDelegate;
        }

        private void HandleTouchUpInsideWithWeakDelegate(object sender, EventArgs e)
        {
            PresentModalViewController(NewViewController, true);
        }
    }
}