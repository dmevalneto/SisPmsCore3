using SisPmsCore.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SisPmsCore.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string DataNascimento { get; set; }


        public bool Validarlogin()
        {
            string sql = $"select idUsuario, Nome, Email, DataNascimento FROM usuario WHERE Email = '{Email}' AND Senha = '{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    IdUsuario = int.Parse(dt.Rows[0]["idUsuario"].ToString());
                    Nome = (dt.Rows[0]["Nome"].ToString());
                    DataNascimento = (dt.Rows[0]["DataNascimento"].ToString());
                    return true;
                }
            }
            return false;
        }

        public void RegistrarUsuario()
        {
            string dataNascimento = DateTime.Parse(DataNascimento).ToString("yyyy/MM/dd");
            string sql = $"INSERT INTO usuario (Nome, Email, Senha, DataNascimento) VALUES('{Nome}','{Email}','{Senha}','{dataNascimento}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
