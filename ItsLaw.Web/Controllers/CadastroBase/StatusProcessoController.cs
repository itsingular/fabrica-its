using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Web.CustomAutorization;
using ItsLaw.Web.ViewModels;
using ItsLaw.Funcoes;
using ItsLaw.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;


namespace ItsLaw.Web.Controllers
{
    public class StatusProcessoController : Controller
    {

        private readonly IStatusProcesso  _StatusProcesso;
        private readonly IUsuarioPerfil   _Perfil;
        private readonly IUsuario         _UsuarioID;
        ItsLawContext DbContext = new ItsLawContext();

        public StatusProcessoController()
        {
            _StatusProcesso  = new StatusProcessoService();
            _Perfil          = new UsuarioPerfilService();
            _UsuarioID       = new UsuarioService();
            DbContext        = new ItsLawContext();
        }

        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida = new List<StatusProcessoViewModel>();
                var listagem = _StatusProcesso.StatusProcessoListagem(UsuarioSession.Instance.SessionMasterID);
                foreach (var item in listagem)
                {
                    var registro = new StatusProcessoViewModel(item);
                    saida.Add(registro);
                }
                return View(saida);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        //EGS --------------------------------------------- Abrir o registro --------------------------------------
        [AutorizarUsuario(AccessLevel = "Abrir")]
        public ActionResult AbrirAlterarStatusProcesso(int id)
        {
            var dados = _StatusProcesso.StatusProcessoGetById(id);
            var saida = new StatusProcessoViewModel(dados);
            return View(saida);
        }

        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirStatusProcesso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirStatusProcesso(StatusProcessoViewModel Itens)
        {
            try
            {
                //EGS 30.08.2018 Mexer com figura, tenta usar esse
                /* http://gtezini.blogspot.com/2013/09/aspnet-mvc-4-upload-e-visualizacao-de.html
                var binaryData = new Byte[file1.InputStream.Length];
                file1.InputStream.Read(binaryData, 0, (int)file1.InputStream.Length);
                var base64String = Convert.ToBase64String(binaryData, 0, binaryData.Length);
                img.Conteudo = base64String;
                 */

                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _StatusProcesso.StatusProcessoAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "StatusProcesso").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
    
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarStatusProcesso(StatusProcessoViewModel Itens)
        {
            try
            {
                _StatusProcesso.StatusProcessoUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "StatusProcesso").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarStatusProcesso(int id)
        {
            try
            {
                var dados                 = _StatusProcesso.StatusProcessoGetById(id);
                _StatusProcesso.StatusProcessoUpdate(dados);
                return RedirectToAction("Index", "StatusProcesso").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "StatusProcesso").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
        

    }
}