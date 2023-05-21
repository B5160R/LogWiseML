using System.Diagnostics;
using DataInputSetup.Infrastructure;

namespace DataInputSetup.Commands;
public class DockerContainerReg
{
    private readonly SendLogsToApi _apiConn;
    private readonly System.Diagnostics.Process _getDockerLogs;
    private readonly string _dockerContainerId;
    public DockerContainerReg(string dockerContainerId)
    {
        _dockerContainerId = dockerContainerId;
        _getDockerLogs = new System.Diagnostics.Process();
        _getDockerLogs.StartInfo.FileName = "docker";
        _getDockerLogs.StartInfo.UseShellExecute = false;
        _getDockerLogs.StartInfo.RedirectStandardOutput = true;
        _apiConn = new SendLogsToApi();
    } 

    public async Task GetLogsAsync()
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
        _getDockerLogs.StartInfo.Arguments = $"logs {_dockerContainerId} -t";
        _getDockerLogs.Start();
        string output = await _getDockerLogs.StandardOutput.ReadToEndAsync();
        await _apiConn.SendLogs(output);
    }
    public async Task RunDockerLogsAsync()
    {
        Process dockerLogProcess = new Process();
        dockerLogProcess.StartInfo.FileName = "docker";
        dockerLogProcess.StartInfo.UseShellExecute = false;
        dockerLogProcess.StartInfo.RedirectStandardOutput = true;
        dockerLogProcess.StartInfo.Arguments = $"logs {_dockerContainerId} -t --follow";

        // Set up event handler for capturing output data
        dockerLogProcess.OutputDataReceived += async (sender, logs) => await _apiConn.SendDockerLogs(sender, logs);

        // Start the process
        dockerLogProcess.Start();

        // Begin asynchronous read operations on the output stream
        dockerLogProcess.BeginOutputReadLine();

        // Keep the process running continuously
        while (!dockerLogProcess.HasExited)
        {
            // Wait for a short duration before checking if the process has exited
            await Task.Delay(1000);
        }

        // Process has exited, handle any remaining output data
        dockerLogProcess.CancelOutputRead();
    }
}