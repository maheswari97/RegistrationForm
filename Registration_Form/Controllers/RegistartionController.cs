using Microsoft.AspNetCore.Mvc;
using Registration_Form.Models;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Registration_Form.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistartionController : ApiControllerAttribute
    {
        [Route("InserData")]
        [HttpPost]
        public object InsertEmployee(Register Reg)
        {
            try
            {


                    storeBD(Reg.FirstName, Reg.LastName, Reg.Age, Reg.email);
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }


        public string storeBD((string FN,string LN,string Age,string Email){
            string DBconnection = "";

            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `RegisterTable` (`FirstName`, `LastName`,`Age`, `Email`) VALUES ("+ FN + ","+ LN+","+Age+","+Email+"); ";
            BindParams(cmd);
             cmd.ExecuteNonQueryAsync();
            return "Sucess";

        }
    }
}
