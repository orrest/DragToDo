using DragToDo.Services.Abstractions;

namespace DragToDo.Services.Implements;

public class HttpService : IHttpService
{
    public string Name { get => "name"; set => throw new System.NotImplementedException(); }
}
