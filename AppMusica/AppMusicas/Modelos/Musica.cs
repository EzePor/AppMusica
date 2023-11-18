using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMusicas.Modelos
{
   public class Musica
    {
       
        
            public string _id { get; set; }
            public string nombre { get; set; }
            public string artista { get; set; }
            public string genero { get; set; }
            public string portada_url { get; set; }
            public int duracion { get; set; }
            public string video_url { get; set; }
             public string pista_url { get; set; }
             public string letra_cancion { get; set; }

            public override string ToString()
            {
                return nombre + "--"+ artista + "--"+genero;
            }
   }

}

