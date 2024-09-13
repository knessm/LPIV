using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veterinaria
{
    internal class Cachorro
    {
        public string nome;
        public string raca;
        private string id;
        public Dono dono;

        public Cachorro(string nome, string raca, string i ,Dono dono) 
        {
            this.nome = nome;
            this.raca = raca;
            this.dono = dono;
            Id = i;
        }

        //metodo pra validar o identificador do cachorro
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
