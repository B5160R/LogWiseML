namespace DataInputSetup.Commands;
public class DockerContainerReg
{
    private readonly System.Diagnostics.Process _getDockerLogs;
    public DockerContainerReg()
    {
        _getDockerLogs = new System.Diagnostics.Process();
        _getDockerLogs.StartInfo.FileName = "docker";
        _getDockerLogs.StartInfo.UseShellExecute = false;
        _getDockerLogs.StartInfo.RedirectStandardOutput = true;
    } 

    public async Task<string> GetLogsAsync(string dockerContainerId)
    {
        _getDockerLogs.StartInfo.Arguments = $"logs {dockerContainerId}";
        _getDockerLogs.Start();
        string output = await _getDockerLogs.StandardOutput.ReadToEndAsync();
        return output;
    }
}