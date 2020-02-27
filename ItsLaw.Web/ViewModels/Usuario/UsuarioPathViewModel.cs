using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItsLaw.Web.ViewModels
{
    public class UsuarioPathViewModel
    {
        public UsuarioPathViewModel()
        {

        }

        public UsuarioPathViewModel(UsuarioPath Itens)
        {
            IdUsuarioPath = Itens.IdUsuarioPath;
            DsController  = Itens.DsController;
            Descricao     = Itens.Descricao;
            Ativo         = Itens.Ativo;
        }


        public UsuarioPath ToDomain()
        {
            var saida = new UsuarioPath();

            saida.IdUsuarioPath = IdUsuarioPath;
            saida.Descricao     = Descricao;
            saida.DsController  = DsController;
            saida.Ativo         = Ativo;

            return saida;
        }

        public int IdUsuarioPath   { get; set; }
        public string DsController { get; set; }
        public string Descricao    { get; set; }
        public bool   Ativo        { get; set; }



    }
}