using SisPmsCore.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SisPmsCore.Models
{
    public class Admin
    {
        public double Total { get; set; }
        public string Descricao { get; set; }

        public List<Admin> RetornarDadosGragicoPie()
        {
            List<Admin> lista = new List<Admin>();
            Admin item;

            string sql = "select sum(co.nome) as Total, ca.nome  from colaborador as co inner join cargo as ca on co.cargo_idcargo = ca.idcargo  group by nome";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Admin();
                item.Total = double.Parse(dt.Rows[i]["Total"].ToString());
                item.Descricao = dt.Rows[i]["nome"].ToString(); 
                lista.Add(item);
            }
            return lista; 
        }
    }
}
