using System.ComponentModel.Design;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Aplication.Interface;
using Modelo.Domain;

namespace ProjetoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;
        private readonly ICepService _cepService;

        public AlunoController(IAlunoApplication alunoApplication, ICepService cepService)
        {
            _alunoApplication = alunoApplication;
            _cepService = cepService;
        }

        [HttpGet("BuscarDadosAluno/{codigo}")]
        public async Task<IActionResult> BuscarDadosAluno(int codigo)
        {
            try
            {
                Aluno aluno = await _alunoApplication.BuscarAluno(codigo);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("AdicionarAluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody] Aluno aluno)
        {
            try
            {
                await _alunoApplication.AdicionarAluno(aluno);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPatch("AtualizarAluno")]
        public async Task<IActionResult> AtualizarAluno([FromBody] Aluno aluno)
        {
            try
            {
                var aluno1 = await _alunoApplication.AtualizarAluno(aluno);
                return Ok(aluno1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeletarAluno/{codigo}")]
        public async Task<IActionResult> DeletarAluno(int codigo)
        {
            try
            {
                bool res = await _alunoApplication.Excluir(codigo);
                return Ok(new { FoiExcluido = res });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("BuscarCep/{cep}")]
        public async Task<IActionResult> BuscarCep(string cep)
        {

            try
            {
                var endereco = await _cepService.BuscarfEnderecoPorCep(cep);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
