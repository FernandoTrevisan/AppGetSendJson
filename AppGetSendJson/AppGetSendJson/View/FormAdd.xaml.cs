using AppGetSendJson.Model;
using AppGetSendJson.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGetSendJson.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormAdd : ContentPage
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {
                await DataServicePessoa.Cadastrar(new Pessoa
                {
                    Nome = txt_nome.Text,
                    Data_Nasc = dtpck_data_nasc.Date
                });

                await DisplayAlert("Sucesso!", "Nova pessoa Inserida", "OK");

                await Navigation.PushAsync(new View.Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");

            }
            finally
            {
                act_carregando.IsRunning = false;
                act_carregando.IsVisible = false;
            }            
        }
    }
}