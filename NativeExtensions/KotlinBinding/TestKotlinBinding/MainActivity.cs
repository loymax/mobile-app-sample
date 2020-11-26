using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;
using Com.Example.Loymaxkotlinlib;
using Android.Support.Design.Widget;
using Android.Views.InputMethods;
using Android.Content;

namespace TestKotlinBinding
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText _a;
        private EditText _b;
        private TextView _sum;
        private Button _calculateSum;
        private Button _textFromKotlin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            _a = FindViewById<EditText>(Resource.Id.editText_a);
            _b = FindViewById<EditText>(Resource.Id.editText_b);
            _sum = FindViewById<TextView>(Resource.Id.textView_sum);
            _calculateSum = FindViewById<Button>(Resource.Id.button_sum);
            _textFromKotlin = FindViewById<Button>(Resource.Id.button_text);
            _calculateSum.Click += SumEvent;
            _textFromKotlin.Click += TextFromKotlinEvent;
        }

        private void TextFromKotlinEvent(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            HideKeyboard(this);
            string kotlinString = string.Empty;
            try
            {

                kotlinString = LoymaxKotlinIntence.KotlinMethod();
            }
            catch (Exception ex)
            {
                Snackbar.Make(view, ex.Message, Snackbar.LengthLong).SetAction("Action", (View.IOnClickListener)null).Show();
            }

            Snackbar.Make(view, kotlinString, Snackbar.LengthLong).SetAction("Action", (View.IOnClickListener)null).Show();
            HideKeyboard(this);
        }

        private void SumEvent(object sender, EventArgs eventArgs)
        {
            HideKeyboard(this);
            View view = (View)sender;
            try
            {
                _sum.Text = LoymaxKotlinIntence.KotlinMethodSum(
                    int.Parse(_a.Text),
                    int.Parse(_b.Text)
                    ).ToString();
                HideKeyboard(this);
            }
            catch (Exception ex)
            {
                Snackbar.Make(view, ex.Message, Snackbar.LengthLong).SetAction("Action", (View.IOnClickListener)null).Show();
            }
        }

        public static bool HideKeyboard(Activity activity)
        {
            var view = activity.CurrentFocus;
            if (view != null)
            {
                var imm = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                return imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }

            return false;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}