// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.Core {
    /// <summary>Un comentario que solo incorpora texto.</summary>
    public class ComentarioTexto: Comentario {
        /// <summary>Crea un nuevo comentario.</summary>
        /// <param name="pos">La posición en el texto.</param>
        /// <param name="txt">El texto del comentario.</param>
        /// <param name="aut">El autor del comentario.</param>
        public ComentarioTexto(int pos, string txt, string aut)
            :base(pos, txt, aut)
        {
        }

        /// <summary>El texto del comentario.</summary>
        public string Texto {
            get {
                return base.Texto;
            }
            set {
                base.Texto = value;
            }
        }

        public override Tipo GetTipo()
        {
            return Tipo.Texto;
        }

        public override string ToString()
        {
            return $"{base.ToString()} \"{this.Texto}\"";
        }
    }
}
