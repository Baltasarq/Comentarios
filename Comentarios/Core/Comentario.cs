// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


using System;
using System.Xml.Linq;

namespace Comentarios.Core {
    /// <summary>
    /// La clase comentario permite insertar un comentario con respecto
    /// a un texto existente.
    /// </summary>
    public abstract class Comentario
    {
        public enum Tipo { Texto, Imagen };
        
        /// <summary>
        /// Crea un nuevo comentario
        /// </summary>
        /// <param name="pos">Posición en el texto.</param>
        /// <param name="txt">El texto del comentario.</param>
        /// <param name="aut">El autor del comentario.</param>
        protected Comentario(int pos, string txt, string aut)
        {
            this.Posicion = pos;
            this.Texto = txt;
            this.Autor = aut;
        }

        /// <summary>El autor del comentario.</summary>
        public string Autor { get; }

        /// <summary>El texto del comentario.</summary>
        protected string Texto { get; set; }
        
        /// <summary>El contenido del comentario.</summary>
        public virtual string Contenido {
            get {
                return this.Texto;
            }
        }

        /// <summary>La posición en el texto.</summary>
        public int Posicion { get; }

        public abstract Tipo GetTipo();

        public override string ToString()
        {
            return $"{this.Posicion.ToString()}/ ({this.Autor})";
        }
        
        /// <summary>
        /// Crea un nuevo comentario.
        /// </summary>
        /// <param name="tipo">El <see cref="Comentario.Tipo" de comentario./></param>
        /// <param name="pos">La posición en el texto existente.</param>
        /// <param name="contenido">El contenido del comentario.</param>
        /// <param name="autor">El autor del comentario.</param>
        public static Comentario crea(string tipo, int pos, string contenido, string autor)
        {
            Comentario toret = null;

            tipo = tipo.Trim().ToLower();
            
            if ( tipo == Tipo.Texto.ToString().ToLower() ) {
                toret = new ComentarioTexto( pos, contenido, autor );
            }
            else
            if ( tipo == Tipo.Imagen.ToString().ToLower() ) {
                toret = new ComentarioImagen( pos, contenido, autor );
            }

            if ( toret == null ) {
                throw new ArgumentException( $"Tipo {tipo} inexistente.");
            }
            
            return toret;
        }
    }
}
