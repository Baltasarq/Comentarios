// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.Core {
    using System.Text;
    using System.Collections.Generic;
    
    
    /// <summary>Una lista de comentarios sobre un texto existente.</summary>
    public class ListaComentarios {
        /// <summary>Crea una nueva lista de comentarios.</summary>
        public ListaComentarios()
        {
            this.lista = new List<Comentario>();
        }

        /// <summary>
        /// Inserta un nuevo comentario.
        /// </summary>
        /// <param name="c">El objeto <see cref="Comentarios.Core.Documento"/>.</param>
        public void Inserta(Comentario c)
        {
            this.lista.Add( c );
        }

        /// <summary>Devuelve el número de comentarios.</summary>
        public int Num {
            get {
                return this.lista.Count;
            }
        }

        /// <summary>Devuelve todos los comentarios en un nuevo array.</summary>
        public Comentario[] Todos {
            get {
                this.lista.Sort( (c1, c2) => c1.Posicion - c2.Posicion );
                return this.lista.ToArray();
            }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Comentario c in this.lista)
            {
                toret.AppendLine( c.ToString() );
            }

            return toret.ToString();
        }

        List<Comentario> lista;
    }
}
