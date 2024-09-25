namespace Common.SF.Infrastructure.EntityFramework
{
    public static class DefaultConnectionStringHelper
    {
        //TDD
        //public const string DefaultConnectionString = "data source=tddsql001; initial catalog=HarnessOne; integrated security=false; user id=CommercialSystem; password=CommercialSystem; multipleactiveresultsets=true; app=entityframework"; 

        //EMACS *RFQ*
        //public const string DefaultConnectionString = "data source=ukhquatsql001; initial catalog=EMACSDataCollate; integrated security=false; user id=CommercialSystem; password=Com$3ept; multipleactiveresultsets=true; app=entityframework";
        //public const string DefaultConnectionString = "data source=ukhqdbs004; initial catalog=EMACSDataCollate; integrated security=false; user id=CommercialSystem; password=Com$3ept; multipleactiveresultsets=true; app=entityframework";

        //Dsi
        //public const string DefaultConnectionString = "data source=ukhquatsql001; initial catalog=H1.Sales.Dsi; integrated security=false; user id=SrvHarnessOneRFQ; password=nW2*as32c; multipleactiveresultsets=true; app=entityframework";

        //NPA
        public const string DefaultConnectionString = "data source=192.168.53.240; initial catalog=NPA_1.0.3.8; integrated security=false; user id=SQLTestH1RFQ; password=*#V(D*32; multipleactiveresultsets=true; app=entityframework";

        //Helpdesk
        //public const string DefaultConnectionString = "data source = tddsql001; initial catalog = HEAT; integrated security = false; user id = CommercialSystem; password=CommercialSystem; multipleactiveresultsets=true; app=entityframework";

        //UAT
        //public const string DefaultConnectionString = "data source=ukhquatsql001; initial catalog=HarnessOne; integrated security=false; user id=CommercialSystem; password=Com$3ept; multipleactiveresultsets=true; app=entityframework"; 
        //public const string DefaultConnectionString = "data source=ukhquatsql001; initial catalog=H1.GlobalMasters; integrated security=false; user id=CommercialSystem; password=Com$3ept; multipleactiveresultsets=true; app=entityframework"; 

        //MIND
        //  public const string DefaultConnectionString = "data source=172.29.58.207; initial catalog=GlobalMasters; integrated security=False; user id=mrpsa; password=drfuzi; multipleactiveresultsets=True; App=EntityFramework"; 
    }
}
