using App.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace App
{
    public partial class MainPage : ContentPage
    {
         

        public MainPage()
        {
            InitializeComponent();
        }

        private  async void OnCounterClicked(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://viacep.com.br/ws/");
            
            var res = await client.GetAsync($"{ety_cpe.Text}/json/");
           

            if (res.IsSuccessStatusCode)
            {
                var lp = await res.Content.ReadAsStringAsync();
                var resjson = JsonConvert.DeserializeObject<CepModel>(lp);

                if (resjson.erro == true)
                {
                    await DisplayAlert("Alerta", "Cep Não Encontrado", "Ok");
                }
                else
                {
                    lb_cep.Text = $"Cep : {resjson.cep}";
                    lb_bairro.Text = $"Bairro : {resjson.bairro}";
                    lb_logradouro.Text = $"Logradouro : {resjson.logradouro}";
                    lb_ddd.Text = $"DDD : {resjson.ddd}";
                    lb_uf.Text = $"UF : {resjson.uf}";
                }
            }
            else
            {

                await DisplayAlert("alerta","Cep Errado","Ok");

            }


        }
    }

}