using Foundation;
using InfColorPicker;
using System;
using UIKit;

namespace InfColorPickerSample
{
   /* public class ColorSelectedDelegate : InfColorPickerControllerDelegate
    {
        readonly UIViewController parent;

        public ColorSelectedDelegate(UIViewController parent)
        {
            this.parent = parent;
        }

        public override void ColorPickerControllerDidFinish(InfColorPickerController controller)
        {
            parent.View.BackgroundColor = controller.ResultColor;
            parent.DismissViewController(false, null);
        }
    }*/

    public partial class ViewController : UIViewController
    {
        //ColorSelectedDelegate selector;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ChangeColorButton.TouchUpInside += HandleTouchUpInsideWithWeakDelegate;
            //selector = new ColorSelectedDelegate(this);
        }

        private void HandleTouchUpInsideWithWeakDelegate(object sender, EventArgs e)
        {
            InfColorPickerController picker = InfColorPickerController.ColorPickerViewController;
            picker.WeakDelegate = this;
            picker.SourceColor = this.View.BackgroundColor;
            picker.PresentModallyOverViewController(this);
        }

        [Export("colorPickerControllerDidFinish:")]
        public void ColorPickerControllerDidFinish(InfColorPickerController controller)
        {
            View.BackgroundColor = controller.ResultColor;
            DismissViewController(false, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}