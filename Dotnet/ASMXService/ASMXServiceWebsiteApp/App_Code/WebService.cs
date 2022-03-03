using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 

[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    /// <summary>
    /// http://localhost:52648/WebService.asmx/HelloWorld
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    [ScriptMethod(UseHttpGet=false)]
    public string HelloWorld()
    {
        return "Hello World";
    }


    /// <summary>
    /// http://localhost:52648/WebService.asmx/savesomeThing
    /// Body
    /// Content-Type: application/x-www-form-urlencoded
    /// Key -Value
    /// Id  -1
    /// Name-aa
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    [WebMethod]
    [ScriptMethod(UseHttpGet = false,ResponseFormat =ResponseFormat.Json)]
    public string savesomeThing(int Id,string Name)
    {
        return "Hello World";
    }
}
