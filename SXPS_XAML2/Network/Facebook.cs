using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SXPS_XAML.Network
{
    public class FacebookBot
    {
        private static string ACCESS_TOKEN = "EAAybCwedOkMBABBxZAaf84OToQhtanVMZB1pBDYAGgNWR8N6minrWAjuQGXHCOXqlNzfuQlUJh5ygYuTZBZBTQzPT1QHMcni2NDBZCLAMLjvsU0qQFkZCc2z4Rp74HWDDQQfatzlV2Af98JsCqm40dReVXdlA37VkpR9sLlHz9bOoIzWv14gvqodDsu16rm0gZD";

        private static string PAGE_ACCESS_TOKEN = "EAAybCwedOkMBANbUftneAPSc47p2oIkmQYHNrt6Vz2crxIKT1fSOYn0g1AZBN0Iy1HzeiJgT1TWMYllT2YHBFL4tZCLZAtLLMd9PLkg9PZBZARLTNGUijgVrhfcAWMfpPJ3X0ZC5qbZAX2MBDoySCG2WZB6t6Yvdseup2gCnE3BxrYdG4owZAL8aayW8fmDUb5qkZD";
        
        private static string ME = "100002332501274";
        private static string APP_ID = "";


        public static async Task SendAsync()
        {

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://graph.facebook.com/v9.0/me/messages?access_token=EAAybCwedOkMBANbUftneAPSc47p2oIkmQYHNrt6Vz2crxIKT1fSOYn0g1AZBN0Iy1HzeiJgT1TWMYllT2YHBFL4tZCLZAtLLMd9PLkg9PZBZARLTNGUijgVrhfcAWMfpPJ3X0ZC5qbZAX2MBDoySCG2WZB6t6Yvdseup2gCnE3BxrYdG4owZAL8aayW8fmDUb5qkZD"))
                {
                    request.Content = new StringContent("{\n  \"recipient\":{\n    \"id\":\"100002332501274\"\n  },\n  \"message\":{\n    \"text\":\"hello, world!\"\n  }\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");


                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}
