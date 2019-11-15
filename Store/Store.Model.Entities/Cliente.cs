using Newtonsoft.Json;

namespace Store.Model.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Senha { get; set; }

        [JsonProperty("Senha")]
        private string SetSenha
        {
            set { Senha = value; }
        }
    }
}