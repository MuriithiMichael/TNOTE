using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using PortableRest;
using TNote.model;

namespace TNote.database
{
    public class Proxy
    {
        //private const string URL = "http://apicontacts.azurewebsites.net/";
        private const string URL = "http://apinotes.azurewebsites.net/";
        public static async Task<Note> PostNote(Note note)
        {
            var client = new RestClient { BaseUrl = URL };

            RestRequest request = new
                RestRequest("notes/", HttpMethod.Post);
            request.ContentType = ContentTypes.Json;
            request.AddParameter(note);
            var response = await client.ExecuteAsync<Note>(request);

            return response;
        }


        public static List<Note> GetNotes()
        {
            var client = new RestClient { BaseUrl = URL };

            RestRequest request = new
                RestRequest("notes/?user=091681-091775-65014", HttpMethod.Get);

            var response = client.ExecuteAsync<List<Note>>(request);

            return response.Result;
        }
    }
}
