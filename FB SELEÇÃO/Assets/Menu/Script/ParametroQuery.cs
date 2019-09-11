using System;

public class ParametroQuery
{

private string paramName { get; set; }
private string paramValue { get; set; }


public string ParamName
{
    get { return paramName; }
    set { paramName = value; }
}

public string ParamValue    {
    get { return paramValue; }
    set { paramValue = value; }
}

    public ParametroQuery(String ParamName, String ParamValue)
{
    this.ParamName = ParamName;
    this.ParamValue = ParamValue;
}


}

