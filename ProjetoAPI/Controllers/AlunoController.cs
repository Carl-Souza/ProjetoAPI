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
            Retorno<Aluno> retorno = new(null);
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
            Retorno<Aluno> retorno = new(null);
            try
            {
                var resposta = await _alunoApplication.Excluir(codigo);
                retorno.CarregaRetorno(resposta, true, "Aluno deletado com Sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(false, "Problemas ao deletar aluno infomado", 400);
                return BadRequest();
            }

        }



        [HttpGet("BuscarCep/{cep}")]
        public async Task<IActionResult> BuscarCep(string cep)
        {
            Retorno<Endereco> retorno = new(null);
            try
            {
                var endereco = await _cepService.BuscarfEnderecoPorCep(cep);
                retorno.CarregaRetorno(endereco, true, "Busca Realizada com Sucesso", 200);

                return Ok(retorno);

            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(false, "Problemas ao buscar dados do cep infomado", 400);
                return BadRequest();
            }

        }

    }
}
