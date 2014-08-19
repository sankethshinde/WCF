using System.Runtime.Serialization;

[DataContract]
public class ArgumentsEmptyFault
{
    [DataMember]
    public string Error { get; set; }

    [DataMember]
    public string Details { get; set; }
}