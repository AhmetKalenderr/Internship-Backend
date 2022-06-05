using InternShipApi.Core;
using InternShipApi.Entities;
using Newtonsoft.Json;

namespace InternShipApi.Services.Utility
{
    public class TokenUtility
    {

        private readonly Cryption cry = new Cryption();
        public string GenerateTokenUser(User user)
        {
            return cry.Encrypt(JsonConvert.SerializeObject(user));
        }

        public string GenerateTokenCompany(Company company)
        {
            return cry.Encrypt(JsonConvert.SerializeObject(company));
        }

        public User getUserFromToken(string token)
        {
            return JsonConvert.DeserializeObject<User>(cry.Decrypt(token));
        }

        public Company getCompanyFromToken(string token)
        {
            return JsonConvert.DeserializeObject<Company>(cry.Decrypt(token));
        }
    }
}
