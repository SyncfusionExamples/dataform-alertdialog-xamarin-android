# How to add DataForm(SfDataForm) in AlertDialog in Xamarin.Android ?
You can add **SfDataForm** to alert dialog using the [AlertDialog](https://docs.microsoft.com/en-us/dotnet/api/android.app.alertdialog?view=xamarin-android-sdk-9) builder in Xamarin.Android.

Initialize SfDataForm, set DataObject and other requirements of SfDataForm in the button click event handler.

``` c#
private void OnLogin(object sender, System.EventArgs e)
{
var dataForm = new SfDataForm(this);
dataForm.DataObject = new LoginInfo();
dataForm.CommitMode = CommitMode.PropertyChanged;
dataForm.RegisterEditor("Password", "Password");
…
}
```
Initialize the [AlertDialog.Builder](https://docs.microsoft.com/en-us/dotnet/api/android.app.alertdialog.builder?view=xamarin-android-sdk-9) and set SfDataForm as builder view.
``` c#
private void OnLogin(object sender, System.EventArgs e)
{
…
var builder = new AlertDialog.Builder(this);
builder.SetCancelable(false);
builder.SetTitle("Enter credentials");
builder.SetPositiveButton("Ok", (s1, e1) => {
});
builder.SetView(dataForm);
…
}
```
For **AlertDialog**, set [SoftInptMode](https://docs.microsoft.com/en-us/dotnet/api/android.views.window.setsoftinputmode?view=xamarin-android-sdk-9#Android_Views_Window_SetSoftInputMode_Android_Views_SoftInput_) to specify the action needs to be done on showing the soft keyboard. And, clear the [NotFocusable](https://docs.microsoft.com/en-us/dotnet/api/android.views.window.clearflags?view=xamarin-android-sdk-9#Android_Views_Window_ClearFlags_Android_Views_WindowManagerFlags_) flags to enable the soft keyboard and focus the fields of SfDataForm.
``` c#
private void OnLogin(object sender, System.EventArgs e)
{
            …

            AlertDialog dialog = builder.Show();
            dialog.Window.SetSoftInputMode(SoftInput.AdjustPan);
            dialog.Window.ClearFlags(WindowManagerFlags.NotFocusable | WindowManagerFlags.AltFocusableIm);
}
```
**Output**

![DataFormAlertDialog](https://github.com/SyncfusionExamples/dataform-alertdialog-xamarin-android/blob/master/Screenshot/DataFormAlertDialog.png)
