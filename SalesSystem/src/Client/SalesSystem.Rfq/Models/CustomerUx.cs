namespace SalesSystem.Rfq.Models
{
    //message CustomerGrpc
    //{
    //    google.protobuf.StringValue Id = 1;
    //    google.protobuf.StringValue CustomerBusinessGroupCode = 2;
    //    google.protobuf.StringValue CustomerBusinessGroupName = 3;
    //    google.protobuf.StringValue SEWSEBusinessTeam = 4;
    //    google.protobuf.BoolValue IsActive = 5;
    //}
    public class CustomerUx
    {
        public string? Id
        { get; set; }
        public string? CustomerBusinessGroupCode
        { get; set; }
        public string? CustomerBusinessGroupName
        { get; set; }
        public string? SEWSEBusinessTeam
        { get; set; }
        public bool IsActive
        { get; set; }
    }
}
