﻿using BoletoNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaudeSemFronteiras.Application.Documents.Commands;
using SaudeSemFronteiras.Application.Invoices.Commands;
using SaudeSemFronteiras.Application.Invoices.Queries;
using SaudeSemFronteiras.Application.Invoices.Services;

namespace SaudeSemFronteiras.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IInvoiceQueries _invoiceQueries;
    private readonly InvoiceService _invoiceService;

    public InvoiceController(IMediator mediator, IInvoiceQueries invoiceQueries, InvoiceService invoiceService)
    {
        _mediator = mediator;
        _invoiceQueries = invoiceQueries;
        _invoiceService = invoiceService;
    }

    [HttpGet("ticket/html/{invoiceId}")]
    public async Task<IActionResult> GetTicketDoctorHtml(long invoiceId, CancellationToken cancellationToken)
    {
        var ticketHtml = _invoiceService.GetBoleto(invoiceId, cancellationToken);
        if (ticketHtml == null)
        {
            return BadRequest();
        }
        return Ok(ticketHtml);
    }


    [HttpGet("ticket/typeableLine/{invoiceId}")]
    public async Task<IActionResult> GetTicketTypeableLine(long invoiceId, CancellationToken cancellationToken)
    {
        var typeableLine = _invoiceService.GenerateLineDigitavel(invoiceId, cancellationToken);

        return Ok(typeableLine);
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetInvoicesByDoctorId(long doctorId, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceQueries.GetInvoiceByDoctorIdQuery(doctorId, cancellationToken);

        return Ok(invoices);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetInvoicesByPatientId(long patientId, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceQueries.GetInvoiceByPatientQuery(patientId, cancellationToken);

        return Ok(invoices);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ChangeInvoice([FromBody] ChangeInvoiceCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }

    [HttpDelete("{invoiceId}")]
    public async Task<IActionResult> DeleteInvoice(long invoiceId, CancellationToken cancellationToken)
    {
        var command = new DeleteInvoiceCommand { Id = invoiceId };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
