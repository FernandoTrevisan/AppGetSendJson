using AppGetSendJson.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppGetSendJson.Service
{
    public class DataServicePessoa : DataService
    {
        /**
         * $data = json_decode(file_get_contents('php://input'));



            $dados_cliente = array(
                'nome' => ucwords(strtolower($data->Nome)),
                'cnpj' => String_Utils::toNumber($data->Cnpj),
                'email' => strtolower($data->Email),
                'contato' => ucwords(strtolower($data->Contato))
            );
         */

        public static async Task<List<Pessoa>> GetPessoasAsync()
        {
            string rota = servidor + "/pessoa";

            string json = await DataService.GetDataFromService(rota);

            List<Pessoa> arr_pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(json);

            return arr_pessoas;
        }
        

        public static async Task<bool> Cadastrar(Pessoa c)
        {
            string rota = servidor + "/pessoa/salvar";

            var json_a_enviar = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_a_enviar, rota);



            /*using (HttpClient client = new HttpClient())
            {
                //HttpResponseMessage response = await PostDataToService(json, rota).ConfigureAwait(false);

                /*if (response.IsSuccessStatusCode)
                {
                    return true;
                    //string json = response.Content.ReadAsStringAsync().Result;

                    //end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());*/


            return true;
        }        
    }
}
