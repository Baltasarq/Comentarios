// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.Core.Persistencia {
    using System;
    using System.Xml.Linq;

    
    public class XmlDocumento {
        /// <summary>Crea un nuevo objeto conversor a XML.</summary>
        /// <param name="c">El comentario a convertir.</param>
        public XmlDocumento(Documento c)
        {
            this.Documento = c;
        }

        /// <summary>El objeto <see cref="Documento"/> sobre el que se trabaja.</summary>
        public Documento Documento { get; }

        /// <summary>
        /// Genera una estructura XML con el comentario dado.
        /// </summary>
        /// <returns>
        /// Un objeto <see cref="XElement"/> con toda la info
        /// del <see cref="Documento"/> dado.
        /// </returns>
        public XElement ToXml()
        {
            return new XElement( TagDocumento,
                        new XElement( TagTexto, this.Documento.Texto ),
                        new XmlListaComentarios( this.Documento.ListaComentarios ).ToXml() );
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

        /// <summary>
        /// Recupera un documento de un objeto XElement.
        /// </summary>
        /// <param name="node">El objeto <see cref="XElement"/>
        /// del que recupera el documento.</param>
        /// <returns>El objeto <see cref="Documento"/> con toda la info.</returns>
        public static Documento RecuperaDe(XElement node)
        {
            return new Documento(
                            node.Element( TagTexto ).Value,
                            XmlListaComentarios.RecuperaDe( 
                                                node.Element( XmlListaComentarios.TagComentarios ) ) );
        }
        
        /// <summary>
        /// Recupera un objeto de un archivo XML.
        /// </summary>
        /// <param name="nf">El nombre del archivo.</param>
        /// <returns>El objeto <see cref="Documento"/> con toda la info.</returns>
        public static Documento Recupera(string nf)
        {
            return RecuperaDe( XElement.Load( nf ) );
        }
        
        const string TagDocumento = "documento";
        const string TagTexto = "texto";
    }
}
