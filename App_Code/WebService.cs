using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]


[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

       
    }

    DataClassesDataContext dc = new DataClassesDataContext();
    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }
    [WebMethod]
    public string obtenerDatos(string id) {

        var json = "";
        var contacto = from resultado in dc.usuarios
                       where resultado.id == Int32.Parse(id)
                       select resultado;

        JavaScriptSerializer jss = new JavaScriptSerializer();
       json =  jss.Serialize(contacto);
        return json;
    }
    
}
