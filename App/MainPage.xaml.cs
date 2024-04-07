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
                lb_cep.Text = resjson.cep;
                lb_bairro.Text = resjson.bairro;
                lb_logradouro.Text = resjson.logradouro;
                lb_ddd.Text = resjson.ddd;
                lb_uf.Text = resjson.uf;
                lb_complemento.Text = resjson.complemento;
            }
            else
            {
               
                
                lb_cep.Text = "CEP Informado Errado";

            }


        }
    }

}