using BarberAPI.DTO;
using BarberAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : Controller
{
    private readonly AppDbContext _context;

    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("ObterUsuarioById")]
    public async Task<IActionResult> ObterUsuarioById(string Login, string Senha)
    {
        var usuario = await _context.Usuarios
            .Where(x => x.Login == Login && x.Senha == Senha)
            .FirstOrDefaultAsync();

        return Ok(usuario);
    }

    [HttpGet("GetUsuario Por Id")]
    public async Task<ActionResult<UsuariosDTO>> InsertUsuarioss()
    {
        return null;
    }
}