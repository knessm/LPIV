using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veterinaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {          
            try
            {
                //tira as mascaras dos maskedtextbox
                maskTxtBoxId.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                maskTxtBoxCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                
                //instancia a classe do banco de dados
                DataBaseManager bd = new DataBaseManager("bdveterinaria");

                //buscar dono
                string comandoD = string.Format("Select * From Dono Where cpf = '{0}'", maskTxtBoxCPF.Text);
                DataTable tabela = bd.BuscarDono(comandoD);
                if(tabela.Rows.Count > 0)
                {
                    string nome, cpf;
                    for(int i = 0; i < tabela.Rows.Count; i++)
                    {
                        nome = tabela.Rows[i].ToString();
                        cpf = tabela.Rows[i].ToString();
                        Dono dono = new Dono(nome, cpf);

                        //cadastra cachorro

                        Cachorro c = new Cachorro(txtNome.Text, txtRaca.Text,maskTxtBoxId.Text ,dono);
                        string comando = string.Format("Insert into cachorro(nome,raca,identificador,dono_id) Values('{0}','{1}','{2}','{3}')", c.nome, c.raca,c.Id,maskTxtBoxCPF.Text);
                        bd.CadastrarCachorro(comando);

                    }
                }
                //retorna as mascaras dos maskedtextbox
                maskTxtBoxCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                maskTxtBoxId.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btntTeste_Click(object sender, EventArgs e)
        {
        }
    }
}
