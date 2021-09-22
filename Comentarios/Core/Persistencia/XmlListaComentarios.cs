// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.Core.Persistencia {
    using System.Xml.Linq;

    
    public class XmlListaComentarios {
        public const string TagComentarios = "comentarios";
        
        /// <summary>
        /// Crea un nuevo objeto para manejar persistencia XML sobre un objeto
        /// <see cref="ListaComentarios"/>.
        /// </summary>
        /// <param name="lista">El objeto <see cref="ListaComentarios"/>.</param>
        public XmlListaComentarios(ListaComentarios lista)
        {
            this.ListaComentarios = lista;
        }

        /// <summary>
        /// Transforma una lista de comentarios en XML.
        /// </summary>
        /// <returns>Un objeto <see cref="XElement"/> con toda la info.</returns>
        public XElement ToXml()
        {
            XElement toret = new XElement( TagComentarios );

            foreach (Comentario c in this.ListaComentarios.Todos) {
                toret.Add( new XmlComentario( c ).ToXml() );
            }

            return toret;
        }

        /// <summary>
        /// Guarda el XML de la <see cref="ListaComentarios"/> en un archivo.
        /// </summary>
        /// <param name="nf">El nombre del archivo.</param>
        public void Guarda(string nf)
        {
            this.ToXml().Save( nf );
        }

        public static ListaComentarios Recupera(string nf)
        {
            return RecuperaDe( XElement.Load( nf ) );
        }

        public static ListaComentarios RecuperaDe(XElement nodo)
        {
            var toret = new ListaComentarios();
            
            foreach (XElement subNodo in nodo.Elements()) {
                toret.Inserta( XmlComentario.RecuperaDe( subNodo ) );
            }

            return toret;
        }
        
        /// <summary>La lista de comentarios sobre la que trabajar.</summary>
        public ListaComentarios ListaComentarios { get;  }
    }
}
