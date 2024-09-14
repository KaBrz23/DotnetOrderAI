﻿using DotnetOrderAI.Models;
using DotnetOrderAI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region Injeção de dependência
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        #endregion

        #region GET para buscar todos os usuarios
        [HttpGet]
        public async Task<ActionResult> getUsuario()
        {
            try
            {
                return Ok(await usuarioRepository.GetUsuarios());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }
        #endregion

        #region GET para buscar um usuario usando o ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> getUsuario(int id)
        {
            try
            {
                var result = await usuarioRepository.GetUsuario(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }
        #endregion

        #region POST para criar um novo usuario
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> createEmpregado([FromBody]Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();

                var result = await usuarioRepository.AddUsuario(usuario);

                return CreatedAtAction(nameof(getUsuario), new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }
        #endregion

        #region PUT para atualizar um usuario
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Usuario>> UpdateEmrpegado([FromBody] Usuario usuario)
        {
            try
            {
                var result = await usuarioRepository.GetUsuario(usuario.Id);
                if (result == null) return NotFound($"Empregado chamado = {usuario.nome} não encontrado");

                return await usuarioRepository.UpdateUsuario(usuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }
        #endregion

        #region DELETE para deletar um empregado
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            try
            {
                var result = await usuarioRepository.GetUsuario(id);
                if (result == null) return NotFound($"Empregado com id = {id} não encontrado");

                usuarioRepository.DeleteUsuario(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
        #endregion
    }
}