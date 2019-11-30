using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api")]
    public class EnderecosController : ControllerBase
    {
        private readonly Context _context;

        public EnderecosController(Context context)
        {
            _context = context;
        }

        [HttpGet("Endereco/Enderecos")]
        public IEnumerable<ConsultaEnd> GetAll()
        {
            List<ConsultaEnd> enderecos = _context.ConsultaEnd.ToList();
            return enderecos;
        }

        [HttpGet("Endereco/Enderecos/{cep}")]
        public IEnumerable<ConsultaEnd> GetPorCep(string cep)
        {
            var endereco = _context.ConsultaEnd.Where(s => s.Cep == cep);
            return endereco;
        }

        [HttpGet("Endereco/EnderecosPorEstado/{uf}")]
        public IEnumerable<ConsultaEnd> GetPorEstado(string uf)
        {
            List<ConsultaEnd> enderecos = _context.ConsultaEnd.Where(s => s.Uf == uf).ToList();
            return enderecos;
        }
    }
}