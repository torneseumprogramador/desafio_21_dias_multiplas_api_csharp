using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UsuarioAPI.Models;
using UsuarioAPI.Servicos;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        Contexto _dbContext;
        public UsuariosController(Contexto dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        [Route("/usuarios")]
        public async Task<List<Usuario>> Index()
        {
            var usuarios = await _dbContext.Usuarios.ToListAsync();
            return usuarios;
        }

        [HttpGet]
        [Route("/usuarios/{id}")]
        public async Task<ActionResult> Show(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if(usuario == null) return StatusCode(404, new { Erro = "Registro não encontrado." });
            return StatusCode(200, usuario);
        }

        [HttpPost]
        [Route("/usuarios")]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            var existeEmailOutroUsuario = (await _dbContext.Usuarios.Where(u => u.Email.ToLower() == usuario.Email.ToLower()).CountAsync()) > 0;
            if(existeEmailOutroUsuario)
                return StatusCode(400, new { Erro = "O email enviado já foi utilizado" });

            usuario.DataCriacao = DateTime.Now;
            usuario.DataAtualizacao = DateTime.Now;

            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();

            return StatusCode(201, usuario);
        }

        [HttpPut]
        [Route("/usuarios/{id}")]
        public async Task<ActionResult> Update(int id, Usuario usuario)
        {
            var usuarioBase = await _dbContext.Usuarios.FindAsync(id);
            if(usuarioBase == null)
                return StatusCode(404, new { Erro = "O usuário enviado não existe no banco de dados" });

            var existeEmailOutroUsuario = (await _dbContext.Usuarios.Where(u => u.Email.ToLower() == usuario.Email.ToLower() && u.Id != id).CountAsync()) > 0;
            if(existeEmailOutroUsuario)
                return StatusCode(400, new { Erro = "O email enviado já existe para outro usuário" });

            usuarioBase.Nome = usuario.Nome;
            usuarioBase.Email = usuario.Email;
            usuarioBase.Senha = usuario.Senha;
            usuarioBase.Observacao = usuario.Observacao;
            usuarioBase.DataAtualizacao = DateTime.Now;

            _dbContext.Usuarios.Update(usuarioBase);
            await _dbContext.SaveChangesAsync();

            return StatusCode(200, usuario);
        }

        [HttpDelete]
        [Route("/usuarios/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioBase = await _dbContext.Usuarios.FindAsync(id);
            if(usuarioBase == null)
                return StatusCode(404, new { Erro = "O usuário enviado não existe no banco de dados" });

            _dbContext.Usuarios.Remove(usuarioBase);
            await _dbContext.SaveChangesAsync();

            return StatusCode(204);
        }
    }
}
