using System;

public interface IGlobalMessage
{
    event EventHandler<string> message;
}
