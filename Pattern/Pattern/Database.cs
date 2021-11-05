using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Pattern
{
    public class Database
    {
        //"Data Source" kısmına kendi "Server Name"inizi yazmanız gerekmektedir.
        public SqlConnection baglanti = new SqlConnection("Data Source= ;Initial Catalog=Alisveris;Integrated Security=True");
    }

    
}
