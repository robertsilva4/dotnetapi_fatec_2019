using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Store.BusinessLogic.BL;
using System.Security.Claims;
using Store.Model.Entities;
using System.Reflection;

namespace Store.Api.Models
{
    public class CarregarClienteAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var cliente = this.Cliente(actionContext);

            if (cliente != null)
            {
                var TypeController = actionContext.ControllerContext.Controller.GetType();
                MethodInfo methodInfo = TypeController.GetMethod("SetCliente");
                methodInfo.Invoke(actionContext.ControllerContext.Controller, new object[] { cliente });
            }

            base.OnActionExecuting(actionContext);
        }

        private Cliente Cliente(HttpActionContext actionContext)
        {
            var claims = ((ClaimsIdentity)actionContext.RequestContext.Principal.Identity).Claims.ToList();
            if (claims.Count == 0)
                return null;

            var idCliente = Convert.ToInt32(claims.Find(t => t.Type == "idUser").Value);

            using (ClienteBL ClienteBL = new ClienteBL())
                return ClienteBL.Consultar(idCliente);
        }
    }
}