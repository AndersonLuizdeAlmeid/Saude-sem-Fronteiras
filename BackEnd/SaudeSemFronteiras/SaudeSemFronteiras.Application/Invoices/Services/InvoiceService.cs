using SaudeSemFronteiras.Application.Invoices.Dtos;
using SaudeSemFronteiras.Application.Invoices.Queries;
using SaudeSemFronteiras.Application.Invoices.Repository;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;

namespace SaudeSemFronteiras.Application.Invoices.Services;
public class InvoiceService
{
    private readonly IInvoiceQueries _invoiceQueries;
    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceService(IInvoiceQueries invoiceQueries, IInvoiceRepository invoiceRepository)
    {
        _invoiceQueries = invoiceQueries;
        _invoiceRepository = invoiceRepository;
    }

    public string GetBoleto(long invoiceId, CancellationToken cancellationToken)
    {
        if (invoiceId == 0)
            return null;

        var invoiceCompleteDto = _invoiceQueries.GetDataToBoleto(invoiceId, cancellationToken);

        if (invoiceCompleteDto.Result == null)
            return null;

        var html = GenerateInvoiceHtml(invoiceCompleteDto.Result);
        return html;
    }

    public string GenerateLineDigitavel(long invoiceId, CancellationToken cancellationToken)
    {
        var invoiceCompleteDto = _invoiceQueries.GetDataToBoleto(invoiceId, cancellationToken);

        if (invoiceCompleteDto.Result == null)
            return null;

        string banco = "123";
        string moeda = "9";
        string valor = ((long)(invoiceCompleteDto.Result.Value * 100)).ToString("D10"); // Valor em centavos
        string dataVencimento = invoiceCompleteDto.Result.DueDate.ToString("yyMMdd"); // Data de vencimento

        string linhaDigitavel = $"{banco}{moeda}{valor}{dataVencimento}";

        return linhaDigitavel;
    }


    public string GenerateInvoiceHtml(InvoiceCompleteDto invoice)
    {
        string banco = "123";
        string moeda = "9";
        string valor = ((long)(invoice.Value * 100)).ToString("D10"); // Valor em centavos
        string dataVencimento = invoice.DueDate.ToString("yyMMdd"); // Data de vencimento

        string linhaDigitavel = $"{banco}{moeda}{valor}{dataVencimento}";

        // Gera o código de barras
        var barcodeWriter = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.CODE_128,
            Options = new EncodingOptions
            {
                Height = 100,  // Altura do código de barras
                Width = 290,   // Largura do código de barras
                Margin = 0    // Margem em torno do código
            }
        };

        var pixelData = barcodeWriter.Write(linhaDigitavel.ToString());  // Gere o código de barras com base no Id da fatura
        using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
        using var ms = new MemoryStream();

        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
        try
        {
            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }

        // Salva o código de barras em um stream de memória
        bitmap.Save(ms, ImageFormat.Png);
        var base64Barcode = Convert.ToBase64String(ms.ToArray());

        // Converte a logo em Base64
        var base64Logo = ConvertImageToBase64("C:\\Users\\Micro\\Desktop\\Projeto final\\Saude-sem-Fronteiras\\BackEnd\\Saude-sem-Fronteiras\\BackEnd\\SaudeSemFronteiras\\SaudeSemFronteiras.Common\\Utils\\logo_inverted.png");
        var base64Banco = ConvertImageToBase64("C:\\Users\\Micro\\Desktop\\Projeto final\\Saude-sem-Fronteiras\\BackEnd\\Saude-sem-Fronteiras\\BackEnd\\SaudeSemFronteiras\\SaudeSemFronteiras.Common\\Utils\\Nubank.png");

        // Incorpora as imagens no HTML como Base64
        return $@"
                    <!DOCTYPE html>
                    <html lang='pt-BR'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Fatura - {invoice.Id}</title>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                margin: 20px;
                                background-color: #f4f4f4;
                            }}
                            .container {{
                                background-color: white;
                                padding: 20px;
                                border-radius: 8px;
                                box-shadow: 0 2px 10px rgba(0,0,0,0.1);
                            }}
                            h1 {{
                                text-align: center;
                                color: #333;
                            }}
                            .recibo, .boleto {{
                                border: 1px solid #000;
                                padding: 10px;
                                margin-bottom: 20px;
                            }}
                            .header {{
                                display: flex;
                                justify-content: space-between;
                                align-items: center;
                                margin-bottom: 20px;
                            }}
                            .header div {{
                                flex: 1;
                            }}
                            .logo {{
                                font-size: 18px;
                                font-weight: bold;
                                color: red;
                            }}
                            table {{
                                width: 100%;
                                border-collapse: collapse;
                                margin-bottom: 10px;
                            }}
                            th, td {{
                                border: 1px solid #ddd;
                                padding: 8px;
                                text-align: left;
                            }}
                            th {{
                                background-color: #6A5ACD;
                                color: white;
                            }}
                            .barcode {{
                                text-align: center;
                                margin-top: 20px;
                            }}
                            .linha-digitavel {{
                                text-align: center;
                                font-size: 14px;
                                margin-top: 10px;
                            }}
                            .footer {{
                                text-align: center;
                                margin-top: 20px;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <!-- Recibo do Pagador -->
                            <div class='recibo'>
                                <div class='header'>
                                    <div class='logo'>
                                        <img src='data:image/png;base64,{base64Logo}' alt='Logo' style='max-width: 100px;' />
                                    </div>
                                    <div>Recibo do Pagador</div>
                                </div>
                                <table>
                                    <tr>
                                        <th>Beneficiário</th>
                                        <td>{invoice.NameReceiver}</td>
                                    </tr>
                                    <tr>
                                        <th>Pagador</th>
                                        <td>{invoice.NamePayer}</td>
                                    </tr>
                                    <tr>
                                        <th>Data de Vencimento</th>
                                        <td>{invoice.DueDate.ToString("dd/MM/yyyy")}</td>
                                    </tr>
                                    <tr>
                                        <th>Valor</th>
                                        <td>R$ {invoice.Value:F2}</td>
                                    </tr>
                                </table>
                            </div>

                            <!-- Boleto Bancário -->
                            <div class='boleto'>
                                <div class='header'>
                                    <div class='logo'>
                                        <img src='data:image/png;base64,{base64Banco}' alt='Logo' style='max-width: 100px;' />
                                    </div>
                                    <div>NUBANK</div>
                                </div>
                                <table>
                                    <tr>
                                        <th>Local de Pagamento</th>
                                        <td>Pagável em qualquer banco até a data de vencimento.</td>
                                    </tr>
                                    <tr>
                                        <th>Agencia</th>
                                        <td>{invoice.Agency}</td>
                                    </tr>
                                    <tr>
                                        <th>Conta</th>
                                        <td>{invoice.Account}</td>
                                    </tr>
                                    <tr>
                                        <th>Digito</th>
                                        <td>{invoice.Digit}</td>
                                    </tr>
                                    <tr>
                                        <th>Data de Vencimento</th>
                                        <td>{invoice.DueDate.ToString("dd/MM/yyyy")}</td>
                                    </tr>
                                    <tr>
                                        <th>Valor</th>
                                        <td>R$ {invoice.Value:F2}</td>
                                    </tr>
                                </table>

                                <div class='barcode'>
                                    <img src='data:image/png;base64,{base64Barcode}' alt='Código de Barras'>
                                </div>

                                <div class='linha-digitavel'>
                                    {linhaDigitavel}
                                </div>
                            </div>

                            <div class='footer'>
                                <p>Obrigado por utilizar nossos serviços!</p>
                            </div>
                        </div>
                    </body>
                    </html>";
    }

    // Função auxiliar para converter imagem para Base64
    public string ConvertImageToBase64(string imagePath)
    {
        byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return Convert.ToBase64String(imageBytes);
    }

    public void VerifyInvoices(long id, short isDoctor, CancellationToken cancellationToken)
    {
        if (isDoctor == 1)
        {
            _invoiceRepository.UpdateDoctorInvoices(id, cancellationToken);
        }
        else
        {
            _invoiceRepository.UpdatePatientInvoices(id, cancellationToken);
        }
    }
}
