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
        /*
            Usage:  docker logs [OPTIONS] CONTAINER

            Fetch the logs of a container

            Options:
                --details        Show extra details provided to logs
            -f, --follow         Follow log output
                --since string   Show logs since timestamp (e.g.
                                2013-01-02T13:23:37Z) or relative (e.g. 42m for 42
                                minutes)
            -n, --tail string    Number of lines to show from the end of the logs
                                (default "all")
            -t, --timestamps     Show timestamps
                --until string   Show logs before a timestamp (e.g.
                                2013-01-02T13:23:37Z) or relative (e.g. 42m for 42
                                minutes)
        */
        _getDockerLogs.StartInfo.Arguments = $"logs -t {dockerContainerId}";
        _getDockerLogs.Start();
        string output = await _getDockerLogs.StandardOutput.ReadToEndAsync();
        return output;
    }
}