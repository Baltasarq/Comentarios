// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.Core.Persistencia {
    using System;
    using System.Xml.Linq;

    
    public class XmlComentario {
        /// <summary>Crea un nuevo objeto conversor a XML.</summary>
        /// <param name="c">El comentario a convertir.</param>
        public XmlComentario(Comentario c)
        {
            this.Documento = c;
        }

        /// <summary>El objeto <see cref="Documento"/> sobre el que se trabaja.</summary>
        public Comentario Documento { get; }

        /// <summary>
        /// Genera una estructura XML con el comentario dado.
        /// </summary>
        /// <returns>
        /// Un objeto <see cref="XElement"/> con toda la info
        /// del <see cref="Documento"/> dado.
        /// </returns>
        public XElement ToXml()
        {
            return new XElement( TagComentario,
                        new XElement( TagTipo, this.Documento.GetTipo().ToString().ToLower() ),
                        new XElement( TagPos, this.Documento.Posicion.ToString() ),
                        new XElement( TagAutor, this.Documento.Autor ),
                        new XElement( TagContenido, this.Documento.Contenido ) );
        }

        /// <summary>
        /// Guarda el XML del <see cref="Documento"/>
        /// relacionado en un archivo dado.
        /// </summary>
        /// <param name="nf">El nombre del archivo a crear.</param>
        public void Guarda(string nf)
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
