namespace DO;



[Serializable]
public class DalNotExistIdException:Exception
{
    public DalNotExistIdException(string message = "Id does not exist") : base( message )
    {

    }
    public DalNotExistIdException(int Id) : base($"ID {Id} does not exist.")
    {

    }
}




[Serializable]
public class DalObjectNotExistException : Exception
{
    public DalObjectNotExistException(string objName = "Object") : base($"{objName} does not exist")
    {

    }
}



[Serializable]
public class DalIdExistsException : Exception
{
    public DalIdExistsException(string message = "Id already exists") : base(message)
    {

    }
    public DalIdExistsException(int Id) : base($"ID {Id} already exists.")
    {

    }
}



[Serializable]
public class DalDirectoryNotExistException : Exception
{
    public DalDirectoryNotExistException(string path = "path") : base($"The directory {path} does not exist.")
    {

    }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}
