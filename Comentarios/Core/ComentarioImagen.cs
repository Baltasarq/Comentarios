// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.Core {
    /// <summary>Un comentario que solo incorpora texto.</summary>
    public class ComentarioImagen: Comentario {
        /// <summary>Crea un nuevo comentario.</summary>
        /// <param name="pos">La posición en el texto.</param>
        /// <param name="url">La URL de la imagen.</param>
        /// <param name="aut">El autor del comentario.</param>
        public ComentarioImagen(int pos, string url, string aut)
            :base(pos, url, aut)
        {
        }

        /// <summary>El texto del comentario.</summary>
        public string URL {
            get {
                return base.Texto;
            }
            set {
                base.Texto = value;
            }
        }
        
        public override Tipo GetTipo()
        {
            return Tipo.Imagen;
        }

        public override string ToString()
        {
            return $"{base.ToString()} \"{this.URL}\"";
        }
    }
}
