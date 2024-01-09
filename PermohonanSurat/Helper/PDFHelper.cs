// PDFHelper.cs
using DinkToPdf;
using DinkToPdf.Contracts;

public class PDFHelper
{
    private readonly IConverter _converter;

    public PDFHelper(IConverter converter)
    {
        _converter = converter;
    }

    public byte[] GeneratePDF(string htmlContent)
    {
        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10, Bottom = 10 }
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = htmlContent,
            WebSettings = { DefaultEncoding = "utf-8" }
        };

        var document = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        return _converter.Convert(document);
    }
}
