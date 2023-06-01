using DataProcessing.Application.Dtos.LogErrorTimeData;
using DataProcessing.Application.Commands.Interfaces;
using CsvHelper;
using System.Globalization;

namespace DataProcessing.Application.Commands.LogErrorTimeData;
public class LogsAnalysisConvertToCSV : IConvertToCSV<LogSendToAnalysisDto>
{
    public async Task<string> ConvertAsync(LogSendToAnalysisDto dto)
    {
        var dummylist = new List<LogSendToAnalysisDto>() { dto };
        using var writer = new StringWriter();
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(dummylist);
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