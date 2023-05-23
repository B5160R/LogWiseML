using DataProcessing.Application.Dtos;
using DataProcessing.Application.Commands.Interfaces;
using CsvHelper;
using System.Globalization;

namespace DataProcessing.Application.Commands;
public class LogsAnalysisConvertToCSV : IConvertToCSV<LogSendToAnalysisDto>
{
    public async Task<string> ConvertAsync(LogSendToAnalysisDto dto)
    {
        using var writer = new StringWriter();
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecord(dto);
        return writer.ToString();
    }

    public async Task<string> ConvertListAsync(IEnumerable<LogSendToAnalysisDto> dto)
    {
        using var writer = new StringWriter();
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(dto);
        return writer.ToString();
    }
}