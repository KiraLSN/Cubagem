using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.BottomNavigation;
using System;

namespace Cubagem
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;
        LinearLayout LayoutRetangular;
        LinearLayout LayoutRedondo;
        LinearLayout LayoutRedondoFuro;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AppCompatButton button1 = FindViewById<AppCompatButton>(Resource.Id.button1);
            button1.Click += Button1_Click;
            AppCompatButton button2 = FindViewById<AppCompatButton>(Resource.Id.button2);
            button2.Click += Button2_Click;
            AppCompatButton button3 = FindViewById<AppCompatButton>(Resource.Id.button3);
            button3.Click += Button3_Click;

            LayoutRetangular = FindViewById<LinearLayout>(Resource.Id.linearLayoutRetangular);
            LayoutRedondoFuro = FindViewById<LinearLayout>(Resource.Id.linearLayoutRedondoFuro);
            LayoutRedondo = FindViewById<LinearLayout>(Resource.Id.linearLayoutRedondo);


            LayoutRetangular.Visibility = ViewStates.Visible;
            LayoutRedondoFuro.Visibility = ViewStates.Gone;
            LayoutRedondo.Visibility = ViewStates.Gone;

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    AutoCompleteTextView campo1 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView1);
                    AutoCompleteTextView campo2 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView2);
                    AutoCompleteTextView campo3 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView3);
                    TextView result1 = FindViewById<TextView>(Resource.Id.resultRetangular);
                    campo1.Text = "";
                    campo2.Text = "";
                    campo3.Text = "";
                    result1.Text = "";
                    LayoutRetangular.Visibility = ViewStates.Visible;
                    LayoutRedondo.Visibility = ViewStates.Gone;
                    LayoutRedondoFuro.Visibility = ViewStates.Gone;
                    textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_dashboard:
                    AutoCompleteTextView campo4 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView4);
                    AutoCompleteTextView campo5 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView5);
                    AutoCompleteTextView campo6 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView6);
                    TextView result2 = FindViewById<TextView>(Resource.Id.resultRedondaFuro);
                    campo4.Text = "";
                    campo5.Text = "";
                    campo6.Text = "";
                    result2.Text = "";
                    LayoutRetangular.Visibility = ViewStates.Gone;
                    LayoutRedondo.Visibility = ViewStates.Gone;
                    LayoutRedondoFuro.Visibility = ViewStates.Visible;
                    textMessage.SetText(Resource.String.title_dashboard);
                    return true;
                case Resource.Id.navigation_notifications:
                    AutoCompleteTextView campo7 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView7);
                    AutoCompleteTextView campo8 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView8);
                    TextView result3 = FindViewById<TextView>(Resource.Id.resultRedonda);
                    result3.Text = "";
                    campo7.Text = "";
                    campo8.Text = "";
                    LayoutRetangular.Visibility = ViewStates.Gone;
                    LayoutRedondo.Visibility = ViewStates.Visible;
                    LayoutRedondoFuro.Visibility = ViewStates.Gone;
                    textMessage.SetText(Resource.String.title_notifications);
                    return true;
            }
            return false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double result;
            double l1, l2, h;
            AutoCompleteTextView lado1 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView1);
            AutoCompleteTextView lado2 = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView2);
            AutoCompleteTextView altura = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView3);
            TextView resultado = FindViewById<TextView>(Resource.Id.resultRetangular);
            l1 = Convert.ToDouble(lado1.Text);
            l2 = Convert.ToDouble(lado2.Text);
            h = Convert.ToDouble(altura.Text);
            result = (l1 * l2 * h) / 2;
            resultado.Text = Convert.ToString(result) + "g";

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double result;
            double d1, d2, h, raio1, raio2;
            AutoCompleteTextView diametroOut = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView4);
            AutoCompleteTextView diametroIn = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView5);
            AutoCompleteTextView altura = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView6);
            TextView resultado = FindViewById<TextView>(Resource.Id.resultRedondaFuro);
            d1 = Convert.ToDouble(diametroOut.Text);
            d2 = Convert.ToDouble(diametroIn.Text);
            h = Convert.ToDouble(altura.Text);
            raio1 = d1 / 2;
            raio2 = d2 / 2;
            result = ((3.14*(raio1*raio1)*h)-(3.14 * (raio2 * raio2) * h)) / 2;
            resultado.Text = Convert.ToString(result)+"g";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            double result;
            double d1, h, raio;
            AutoCompleteTextView diametroOut = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView7);
            AutoCompleteTextView altura = FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView8);
            TextView resultado = FindViewById<TextView>(Resource.Id.resultRedondaFuro);
            d1 = Convert.ToDouble(diametroOut.Text);
            h = Convert.ToDouble(altura.Text);
            raio = d1 / 2;
            result = (3.14 * (raio * raio) * h) / 2;
            resultado.Text = Convert.ToString(result) + "g";
        }

    }
}

