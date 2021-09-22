// Comentarios (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace Comentarios.UI {
    using System;
    using Comentarios.Core;
    using Comentarios.Core.Persistencia;
    
    
    class Program {
        static ListaComentarios CreaDemoComentarios()
        {
            var toret = new ListaComentarios();

            toret.Inserta(
                new ComentarioImagen( 12, "https://en.wikipedia.org/wiki/C_Sharp_(programming_language)#/media/File:C_Sharp_wordmark.svg", "Baltasar") );
            toret.Inserta(
                new ComentarioTexto( 5, "C#", "Baltasar" ) );
            
            return toret;
        }

        static Documento CreaDemoDocumento()
        {
            return new Documento(
                "El lenguaje C# es moderno y funcional.",
                CreaDemoComentarios() );
        }
        
        static void GuardaComentariosXML()
        {
            new XmlListaComentarios( CreaDemoComentarios() ).Guarda( "comentarios.xml" );
        }

        static void RecuperaComentariosXML()
        {
            var lista = XmlListaComentarios.Recupera( "comentarios.xml" );

            foreach (Comentario c in lista.Todos) {
                Console.WriteLine( c );
            }
        }
        
        static void GuardaDocumentoXML()
        {
            new XmlDocumento( CreaDemoDocumento() ).Guarda( "documento.xml" );
        }

        static void RecuperaDocumentoXML()
        {
            Console.WriteLine( XmlDocumento.Recupera( "documento.xml" ) );
        }
        
        static void Main(string[] args)
        {
            GuardaDocumentoXML();
            RecuperaDocumentoXML();
        }
    }
}
