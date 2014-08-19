using System.Runtime.Serialization;

[DataContract]
public class EmployeeIsNotPresentFault
{
    [DataMember]
    public string Error { get; set; }

    [DataMember]
    public string Details { get; set; }
}