using DataProcessing.Application.Dtos;
using DataProcessing.Application.Commands.Interfaces;
using CsvHelper;
using System.Globalization;

namespace DataProcessing.Application.Commands;
public class LogsConvertToCSV : IConvertToCSV<LogQueryResultDto>
{
    public async Task<string> ConvertAsync(IEnumerable<LogQueryResultDto> dto)
    {
        using var writer = new StringWriter();
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(dto);
        return writer.ToString();
    }
}