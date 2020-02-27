using ItsLaw.DAO.Conexao;
using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;



namespace ItsLaw.DAO.SQL
{
    public class UsuarioPerfilDireitoDAO
    {
        public List<UsuarioPerfilDireito> Select(int IdUsuarioPerfil)
        {
            var Conn = new ConexaoSQL();
            DataTable dt = new DataTable();
            StringBuilder SQL = new StringBuilder();
            List<SqlParameter> Param = new List<SqlParameter>();
            var Saida = new List<UsuarioPerfilDireito>();
             
            SQL.AppendLine(" SELECT DIRE.IdUsuarioPerfilDireito, DIRE.IdUsuarioPerfil, PERF.Descricao AS PERFIL_DESCRICAO,                 ");
            SQL.AppendLine("        DIRE.IdUsuarioPath, PATT.Descricao AS PATH_DESCRICAO, PATT.DsController,                               ");
            SQL.AppendLine("        IsNull(DIRE.AcaoEditar  , 0) AcaoEditar  , IsNull(DIRE.AcaoVisualizar, 0) AcaoVisualizar,              ");
            SQL.AppendLine("        IsNull(DIRE.AcaoIncluir , 0) AcaoIncluir , IsNull(DIRE.AcaoExcluir   , 0) AcaoExcluir,                 ");
            SQL.AppendLine("        IsNull(DIRE.AcaoImportar, 0) AcaoImportar, IsNull(DIRE.AcaoImprimir  , 0) AcaoImprimir,                ");
            SQL.AppendLine("        DIRE.IdUsuarioInclusao, DIRE.DtUsuarioInclusao, IsNull(DIRE.IdUsuarioAlteracao, 0) IdUsuarioAlteracao, ");
            SQL.AppendLine("        IsNull(DIRE.DtUsuarioAlteracao, 0) AS DtUsuarioAlteracao                                               ");
            SQL.AppendLine(" FROM   UsuarioPerfilDireito DIRE                                                                              ");
            SQL.AppendLine("        LEFT JOIN UsuarioPerfil PERF ON(PERF.idUsuarioPerfil = DIRE.IdUsuarioPerfil)                           ");
            SQL.AppendLine("        LEFT JOIN UsuarioPath   PATT ON(PATT.idUsuarioPath = DIRE.idUsuarioPath)                               ");
            SQL.AppendLine(" WHERE (DIRE.IdUsuarioPerfil = " + IdUsuarioPerfil + ")                                                        ");
            SQL.AppendLine("   AND (PERF.Ativo = 1)                                                                                        ");
            SQL.AppendLine(" ORDER BY IdUsuarioPerfil, IdUsuarioPath, IdUsuarioPerfilDireito                                               ");

            dt = Conn.ExecutaSelect(SQL.ToString(), Param);

            foreach (DataRow dr in dt.Rows)
            {
                var BO = new UsuarioPerfilDireito();
                bool bAcaoVisualizar = false;
                bool bAcaoEditar     = false;
                bool bAcaoIncluir    = false;
                bool bAcaoExcluir    = false;
                bool bAcaoImprimir   = false;
                bool bAcaoImportar   = false;
                if (Util.VerifyNullDB(dr["AcaoVisualizar"], EnumTipoColuna.Integer) == 1) { bAcaoVisualizar = true; }
                if (Util.VerifyNullDB(dr["AcaoEditar"    ], EnumTipoColuna.Integer) == 1) { bAcaoEditar     = true; }
                if (Util.VerifyNullDB(dr["AcaoIncluir"   ], EnumTipoColuna.Integer) == 1) { bAcaoIncluir    = true; }
                if (Util.VerifyNullDB(dr["AcaoExcluir"   ], EnumTipoColuna.Integer) == 1) { bAcaoExcluir    = true; }
                if (Util.VerifyNullDB(dr["AcaoImprimir"  ], EnumTipoColuna.Integer) == 1) { bAcaoImprimir   = true; }
                if (Util.VerifyNullDB(dr["AcaoImportar"  ], EnumTipoColuna.Integer) == 1) { bAcaoImportar   = true; }

                BO.IdUsuarioPerfilDireito = Util.VerifyNullDB(dr["IdUsuarioPerfilDireito"], EnumTipoColuna.Integer);
                BO.IdUsuarioPerfil        = Util.VerifyNullDB(dr["IdUsuarioPerfil"       ], EnumTipoColuna.Integer);
                BO.IdUsuarioPath          = Util.VerifyNullDB(dr["IdUsuarioPath"         ], EnumTipoColuna.Integer);
                BO.DescricaoAcesso        = Util.VerifyNullDB(dr["PATH_DESCRICAO"        ], EnumTipoColuna.String );
                BO.AcaoVisualizar         = bAcaoVisualizar;
                BO.AcaoEditar             = bAcaoEditar    ; 
                BO.AcaoIncluir            = bAcaoIncluir   ; 
                BO.AcaoExcluir            = bAcaoExcluir   ;
                BO.AcaoImprimir           = bAcaoImprimir  ;
                BO.AcaoImportar           = bAcaoImportar  ;
                BO.IdUsuarioInclusao      = Util.VerifyNullDB(dr["IdUsuarioInclusao" ], EnumTipoColuna.Integer );  
                BO.DtUsuarioInclusao      = Util.VerifyNullDB(dr["DtUsuarioInclusao" ], EnumTipoColuna.Date    );  
                BO.IdUsuarioAlteracao     = Util.VerifyNullDB(dr["IdUsuarioAlteracao"], EnumTipoColuna.Integer); 
                BO.DtUsuarioAlteracao     = Util.VerifyNullDB(dr["DtUsuarioAlteracao"], EnumTipoColuna.Date   );  

                Saida.Add(BO);
            }

            return Saida;
        }
    }
}
