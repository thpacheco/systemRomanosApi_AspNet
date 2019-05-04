using System;
using System.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MongoDB.Bson;
using RomanosApi.Core;
using RomanosApi.Core.Util;
using RomanosApi.Domain.Entities;
using RomanosApi.Domain.Specification.VisitaSpecification;
using RomanosApi.Infrastructure.Repositories;

namespace RomanosApi.Controllers.Visitas
{
    [Route("api/visitas")]
    [ApiController]
    [DisableCors]
    public class VisitaController : ControllerBase
    {
        private readonly Repository<Visita> _visitaRepository = new Repository<Visita>("agendas");

        [HttpGet]
        [Route("")]
        public IActionResult ListarVisitas()
        {
            try
            {

                DateTime date = DateTime.MinValue;

                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                var agenda = _visitaRepository.Listar(c => c.Data == DateTime.Now.Date);

                if (agenda == null) BadRequest("Visitas não encontrado");

                return Ok(agenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("listarPorConsultor/{consultor}")]
        public IActionResult ListarPorConsultor(string consultor)
        {
            try
            {
                var agenda = _visitaRepository.Listar(c => c.Consultor == consultor);

                if (agenda == null) BadRequest("Visitas não encontrado");

                return Ok(agenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("listarPorMes/{mes}")]
        public IActionResult ListarPorMes(string mes)
        {
            try
            {
                DateTime date = DateTime.MinValue;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                var agenda = _visitaRepository.Listar(c => c.Consultor == mes);

                if (agenda == null) BadRequest("Visitas não encontrado");

                return Ok(agenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult SalvarVisita(VisitaDto visita)
        {
            try
            {
                var objVisita = new Visita
                {
                    id = visita.id,
                    Nome = visita.Nome,
                    Consultor = visita.Consultor,
                    Data = new BsonDateTime(DateTime.Parse(visita.Data)),
                    StatusCliente = visita.StatusCliente,
                    Telefone = visita.Telefone,
                    TipoCliente = visita.TipoCliente,
                    TipoVisita = visita.TipoVisita
                };

                _visitaRepository.Inserir(objVisita);

                return Ok(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        // PUT: api/Visita/5
        [HttpPut("atualizar")]
        public IActionResult AtualizarVisita(VisitaDto visita)
        {
            try
            {
                if (visita == null) BadRequest("Erro ao atualizar visita");

                var objVisita = new Visita
                {
                    id = visita.id,
                    Nome = visita.Nome,
                    Consultor = visita.Consultor,
                    Data = new BsonDateTime(DateTime.Parse(visita.Data)),
                    StatusCliente = visita.StatusCliente,
                    Telefone = visita.Telefone,
                    TipoCliente = visita.TipoCliente,
                    TipoVisita = visita.TipoVisita
                };

                _visitaRepository.Atualizar(c => c.id == visita.id, objVisita);

                return Ok(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteVisita(string id)
        {
            try
            {
                _visitaRepository.Excluir(c => c.id == id);

                return Ok(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
