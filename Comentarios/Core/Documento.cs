// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.Core {
    /// <summary>Un documento sobre el que se realizarán comentarios.</summary>
    public class Documento {
        public Documento(string txt)
            :this(txt, new ListaComentarios())
        {
        }

        public Documento(string txt, ListaComentarios lc)
        {
            this.Texto = txt;
            this.ListaComentarios = lc;
        }

        public ListaComentarios ListaComentarios {
            get;
        }

        public string Texto {
            get;
        }

        public override string ToString()
        {
            return $"\"{this.Texto}\"\n{this.ListaComentarios}";
        }
    }
}
