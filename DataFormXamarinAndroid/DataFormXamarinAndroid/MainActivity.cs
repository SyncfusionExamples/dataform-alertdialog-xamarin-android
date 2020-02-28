using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Syncfusion.Android.DataForm;
using AlertDialog = Android.App.AlertDialog;
using Android.Views;
using Android.Graphics;

namespace DataFormXamarinAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            LinearLayout linearLayout = new LinearLayout(this);
            linearLayout.SetHorizontalGravity(GravityFlags.Center);
            linearLayout.SetVerticalGravity(GravityFlags.Center);

            var loginButton = new Button(this);
            loginButton.Text = "Login";
            loginButton.Click += OnLogin;
            loginButton.SetBackgroundColor(Color.LightGray);
            loginButton.SetTextColor(Color.Black);

            linearLayout.AddView(loginButton);
            SetContentView(linearLayout);
        }
        private void OnLogin(object sender, System.EventArgs e)
        {
            var dataForm = new SfDataForm(this);
            dataForm.DataObject = new LoginInfo();
            dataForm.CommitMode = CommitMode.PropertyChanged;
            dataForm.RegisterEditor("Password", "Password");

            var builder = new AlertDialog.Builder(this);
            builder.SetCancelable(false);
            builder.SetTitle("Enter credentials");
            builder.SetPositiveButton("Ok", (s1, e1) => {
            });
            builder.SetView(dataForm);

            AlertDialog dialog = builder.Show();
            dialog.Window.SetSoftInputMode(SoftInput.AdjustPan);
            dialog.Window.ClearFlags(WindowManagerFlags.NotFocusable | WindowManagerFlags.AltFocusableIm);
        }
    }
}