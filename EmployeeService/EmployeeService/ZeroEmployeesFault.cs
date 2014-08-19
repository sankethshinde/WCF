using System.Runtime.Serialization;

[DataContract]
public class ZeroEmployeesFault
{
    [DataMember]
    public string Error { get; set; }

    [DataMember]
    public string Details { get; set; }
}