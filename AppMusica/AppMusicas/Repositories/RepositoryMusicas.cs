using AppMusicas.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppMusicas.Repositories
{
    public class RepositoryMusicas
    {
        string urlApi = "https://proyectofinalmusica-8cfa.restdb.io/rest/musica";
        HttpClient client = new HttpClient();

        public RepositoryMusicas()
        {
            // configuramos que trabajará con respuesta Json.
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("apiKey", "653e8d13e7228f34c4b84998");
        }
        public async Task<ObservableCollection<Musica>> GetAllAsync()
        {
            try
            {
                var response = await client.GetStringAsync(urlApi);
                return
                    JsonConvert.DeserializeObject<ObservableCollection<Musica>>
                (response);
            }
            catch (Exception error)
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", "Hubo un error: " + error.Message, "OK");
                return null;
            }




        }

        public async Task<bool> RemoveAsync(string id)
        {
            var response = await client.DeleteAsync($"{urlApi}/{id}");
            return response.IsSuccessStatusCode;


        }

        public async Task<bool> AddAsync(Musica musica){
            var response = await client.PostAsync(urlApi, new StringContent(JsonConvert.SerializeObject(musica), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> UpdateAsync(Musica musica)
        {
            var response = await client.PutAsync($"{urlApi}/{musica._id}", new StringContent(JsonConvert.SerializeObject(musica), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;

        }


    }

    
}
