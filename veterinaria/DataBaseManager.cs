using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace veterinaria
{
    internal class DataBaseManager
    {
        public string stringcon;
        MySqlCommand cmd;
        MySqlConnection conexao;

        public DataBaseManager(string nome)
        {
            stringcon = "server=localhost;database=" + nome + ";uid=root;pwd='';SSL Mode = None";
        }

        public void CadastrarCachorro(string comando)
        {
            try
            {
                using (conexao = new MySqlConnection(stringcon))
                {
                    conexao.Open();
                    cmd = new MySqlCommand(comando, conexao);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cachorro Cadastrado com sucesso");
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BuscarDono(string comando)
        {          
            try
            {
                using(conexao = new MySqlConnection(stringcon))
                {
                    conexao.Open();
                    DataTable tabela;
                    cmd = new MySqlCommand(comando, conexao);
                    using(MySqlDataReader leitor = cmd.ExecuteReader())
                    {
                        tabela = new DataTable();
                        tabela.Load(leitor);
                    }
                    return tabela;
                }
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }


    }
}
