using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItsLaw.Web.Controllers
{
    public class UsuarioDireitoController : Controller
    {
        #region Atributos

        private readonly IUsuario        _usuario;
        private readonly IUsuarioPath    _path;
        private readonly IUsuarioDireito _direito;

        #endregion

        #region Contrutor
        public UsuarioDireitoController()
        {
            _usuario = new UsuarioService();
            _path = new UsuarioPathService();
            _direito = new UsuarioDireitosService();
        }
        #endregion

        // GET: Direitos
        public ActionResult Index()
        {
            var dados = _usuario.Listagem();

            var saida = new List<UsuarioViewModel>();

            foreach (var item in dados)
            {
                var registro = new UsuarioViewModel(item);
                saida.Add(registro);
            }

            return View(saida);
        }


        public ActionResult AtualizarDireitos(RetornoDireitosViewModel itens)
        {
            _direito.ApagaDireitos(itens.IdUsuarioPerfil);
            _direito.CadastraDireitos(itens.IdUsuarioPerfil, itens.Direito);

            return RedirectToAction("Index");
        }
    }
}
