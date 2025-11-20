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
            Retorno<Aluno> retorno = new(null);
            try
            {
                Aluno aluno = await _alunoApplication.BuscarAluno(codigo);
                retorno.CarregaRetorno(aluno, true, "Busca pelo aluno com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(null, false, "Problemas ao buscar aluno infomado", 400);
                return BadRequest();
            }

        }

        [HttpPost("AdicionarAluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody] Aluno aluno)
        {
            Retorno<Aluno> retorno = new(null);
            try
            {
                await _alunoApplication.AdicionarAluno(aluno);
                retorno.CarregaRetorno(aluno, true, "Aluno adicionado com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(null, false, "Problemas ao adicionar aluno infomado", 400);
                return BadRequest();
            }

        }
        [HttpPatch("AtualizarAluno")]
        public async Task<IActionResult> AtualizarAluno([FromBody] Aluno aluno)
        {
            Retorno<Aluno> retorno = new(null);
            try
            {
                var aluno1 = await _alunoApplication.AtualizarAluno(aluno);
                retorno.CarregaRetorno(aluno1, true, "Aluno atualizado com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(null, false, "Problemas ao atualizar aluno infomado", 400);
                return BadRequest();
            }

        }

        [HttpDelete("DeletarAluno/{codigo}")]
        public async Task<IActionResult> DeletarAluno(int codigo)
        {
            Retorno<Aluno> retorno = new(null);
            try
            {
                bool resposta = await _alunoApplication.Excluir(codigo);
                retorno.CarregaRetorno(null, true, "Aluno deletado com sucesso", 200);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.CarregaRetorno(null, false, "Problemas ao deletar aluno infomado", 400);
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
