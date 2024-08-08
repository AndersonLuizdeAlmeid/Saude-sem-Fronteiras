﻿using SaudeSemFronteiras.Application.Invoices.Domain;

namespace SaudeSemFronteiras.Application.Invoices.Repository;
public interface IInvoiceRepository
{
    Task Insert(Invoice invoice, CancellationToken cancellationToken);
    Task Update(Invoice invoice, CancellationToken cancellationToken);
}
