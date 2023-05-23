using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Dtos.LogErrorTimeData;
using DataProcessing.Domain.Models;

namespace DataProcessing.Application.Commands.LogErrorTimeData;
public class LogPrepForAnalysis : IPrepForAnalysis<LogProcessRequestDto>
{
    private readonly IConvertToCSV<LogSendToAnalysisDto> _convertToCSV;
    public LogPrepForAnalysis(IConvertToCSV<LogSendToAnalysisDto> convertToCSV)
    {
        _convertToCSV = convertToCSV;
    }
    public async Task<string> Prep(LogProcessRequestDto dto)
    {
        var logProcessedModel = new LogProcessedModel("Analysis", dto.Content);
        var analysisDto = new LogSendToAnalysisDto();
        analysisDto.MLType = logProcessedModel.MLType;
        analysisDto.Timestamp = logProcessedModel.Timestamp;

        var csvDto = await _convertToCSV.ConvertAsync(analysisDto);
        return csvDto;
    }
}