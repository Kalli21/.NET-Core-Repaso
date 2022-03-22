using APIClientes.Modelos;
using APIClientes.Modelos.DTO;
using APIClientes.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        protected ResponseDTO _response;

        public UsersController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
            _response = new ResponseDTO();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO user)
        { 
            var respuesta = await _userRepositorio.Register(
                new User 
                { 
                    UserName = user.UserName
                },user.Password);

            if (respuesta == -1)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario ya Existe";
                return BadRequest(_response);
            }

            if (respuesta == -500) { 
                _response.IsSuccess = false ;
                _response.DisplayMessage = "Error al Crear el Usuario";
                return BadRequest(_response);
            }

            _response.DisplayMessage = "Usuario creado con Exito";
            _response.Result = respuesta;

            return Ok(_response);
            
            
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDTO user) 
        {
            var respuesta = await _userRepositorio.Login(user.UserName, user.Password);

            if (respuesta=="nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no existe";
                return BadRequest(_response);
            }

            if (respuesta == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Password incorrecto";
                return BadRequest(_response);
            }

            _response.Result = respuesta;
            _response.DisplayMessage = "Usuario conectado";
            return Ok(_response);
        }
    }
}
