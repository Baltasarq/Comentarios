// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.Core.Persistencia {
    using System;
    using System.Xml.Linq;

    
    public class XmlComentario {
        /// <summary>Crea un nuevo objeto conversor a XML.</summary>
        /// <param name="c">El comentario a convertir.</param>
        public XmlComentario(Comentario c)
        {
            this.Comentario = c;
        }

        /// <summary>El objeto <see cref="Comentario"/> sobre el que se trabaja.</summary>
        public Comentario Comentario { get; }

        /// <summary>
        /// Genera una estructura XML con el comentario dado.
        /// </summary>
        /// <returns>
        /// Un objeto <see cref="XElement"/> con toda la info
        /// del <see cref="Comentario"/> dado.
        /// </returns>
        public XElement ToXml()
        {
            return new XElement( TagComentario,
                        new XElement( TagTipo, this.Comentario.GetTipo().ToString().ToLower() ),
                        new XElement( TagPos, this.Comentario.Posicion.ToString() ),
                        new XElement( TagAutor, this.Comentario.Autor ),
                        new XElement( TagContenido, this.Comentario.Contenido ) );
        }

        /// <summary>
        /// Guarda el XML del <see cref="Comentario"/>
        /// relacionado en un archivo dado.
        /// </summary>
        /// <param name="nf">El nombre del archivo a crear.</param>
        public void GuardaXml(string nf)
        {
            this.ToXml().Save( nf );
        }

        public static Comentario RecuperaDe(XElement node)
        {
            return Comentario.crea(
                            node.Element( TagTipo ).Value,
                            Convert.ToInt32( node.Element( TagPos ).Value ),
                            node.Element( TagContenido ).Value,
                            node.Element( TagAutor ).Value );
        }

        const string TagComentario = "comentario";
        const string TagContenido = "contenido";
        const string TagAutor = "autor";
        const string TagPos = "pos";
        const string TagTipo = "tipo";
    }
}
