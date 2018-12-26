using Microsoft.AspNetCore.Http;
using SisPmsCore.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SisPmsCore.Models
{
    public class Colaborador
    {
        public int idColaborador { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataAdmissao { get; set; }
        public string Telefone { get; set; }
        public int setor_idsetor { get; set; }
        public int cargo_idcargo { get; set; }
        public int ocorrencia_idocorrencia { get; set; }
        public int prestadora_servico_idprestadora_servico { get; set; }
        IHttpContextAccessor HttpContextAccessor;

        public Colaborador()
        {

        }

        //Recebe o contexto para acesso as variaveis de sessão
        public Colaborador(IHttpContextAccessor httpContextAcessor)
        {
            HttpContextAccessor = httpContextAcessor;
        }

        public List<Colaborador> ListaColaborador()
        {
            List<Colaborador> lista = new List<Colaborador>();
            Colaborador item;

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = "SELECT idcolaborador, nome, cpf, data_admissao, telefone, setor_idsetor, cargo_idcargo, ocorrencia_idocorrencia, prestadora_servico_idprestadora_servico FROM colaborador";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Colaborador();
                item.idColaborador = int.Parse(dt.Rows[i]["idcolaborador"].ToString());
                item.Nome = dt.Rows[i]["nome"].ToString();
                item.Cpf = dt.Rows[i]["cpf"].ToString();
                item.DataAdmissao =DateTime.Parse( dt.Rows[i]["data_admissao"].ToString()).ToString("dd/MM/yyy");
                item.Telefone = dt.Rows[i]["telefone"].ToString();
                item.setor_idsetor = int.Parse(dt.Rows[i]["setor_idsetor"].ToString());
                item.cargo_idcargo = int.Parse(dt.Rows[i]["cargo_idcargo"].ToString());
                item.ocorrencia_idocorrencia = int.Parse(dt.Rows[i]["ocorrencia_idocorrencia"].ToString());
                item.prestadora_servico_idprestadora_servico = int.Parse(dt.Rows[i]["prestadora_servico_idprestadora_servico"].ToString());
                lista.Add(item);
            }
            return lista;

        }

        public void SalvarNovoRegistro()
        {
            string dataAdmissao = DateTime.Parse(DataAdmissao).ToString("yyyy/MM/dd");
            string sql = $"INSERT INTO colaborador (nome, cpf, data_admissao, telefone, setor_idsetor, cargo_idcargo, ocorrencia_idocorrencia, prestadora_servico_idprestadora_servico) VALUES ('{Nome}', '{Cpf}','{dataAdmissao}', '{Telefone}', {setor_idsetor}, {cargo_idcargo}, {ocorrencia_idocorrencia}, {prestadora_servico_idprestadora_servico})";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
