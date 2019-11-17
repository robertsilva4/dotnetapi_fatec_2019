using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Store.Model.Entities;
using Store.BusinessLogic.BL;

namespace Store.Api.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (ClienteBL ClienteBL = new ClienteBL())
            {
                var ClienteRequisicao = new Cliente() { Email = context.UserName, Senha = context.Password };
                var UsuarioLogado = ClienteBL.Logar(ClienteRequisicao);

                if (UsuarioLogado != null)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim("user", UsuarioLogado.Email));
                    identity.AddClaim(new Claim("idUser", UsuarioLogado.Id.ToString()));
                    context.Validated(identity);
                }
                else
                    context.SetError("invalid_grant", "Usuário não encontrado ou as credenciais estão inválidas");

                return Task.FromResult<object>(null);
            }
        }

        private string NormalizeUrl(string userName)
        {
            return userName.Replace(' ', '+');
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}