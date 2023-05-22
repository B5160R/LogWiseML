using System;

namespace DataCollection.Domain.Models;

public class LogModel
{
    public int Id { get; private set; }
    public string Content { get; private set; }

    public LogModel(string content)
    {
        Content = content;
    }
    
    internal LogModel()
    {
    }
}