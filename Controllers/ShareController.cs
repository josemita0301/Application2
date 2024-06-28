using Auth0_Blazor.Models;
using Auth0_Blazor.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Auth0_Blazor.Utils;

namespace Auth0_Blazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShareController : ControllerBase
    {
        private readonly EmpleadoService _empleadoService;
        private readonly EncryptSymmetricService _encryptSymmetricService;

        public ShareController(EmpleadoService empleadoService, EncryptSymmetricService encryptSymmetricService)
        {
            _empleadoService = empleadoService;
            _encryptSymmetricService = encryptSymmetricService;
        }

        [HttpGet("get-employees")]
        public async Task<IActionResult> GetData()
        {
            List<Empleado> empleados = await _empleadoService.GetEmpleadosAsync();

            string empleadosToJsonString = JsonConvert.SerializeObject(empleados);

            string encryptedData = _encryptSymmetricService.EncryptSymmetric(empleadosToJsonString);

            return Ok(encryptedData);
        }
    }
}