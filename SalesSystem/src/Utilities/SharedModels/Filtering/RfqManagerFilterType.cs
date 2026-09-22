namespace SharedModels.Filtering
{
    public enum RfqManagerFilterType
    {
        None = 0,
        FilterByCustomerId = 1,
        FilterByLocationId = 2,
        FilterByProjectCode = 3,
        FilterEmacsByExactPartNumber = 4,
        FilterEmacsByContainingPartNumber = 5,
        FilterAdssBySumitomoPartNumber = 6,
        FilterNPRBySumitomoPartNumber = 7,
        FilterCPDBySumitomoPartNumber = 8,
        FilterRFQBySumitomoPartNumber = 9,
        FilterNPRByCustomerNumber = 10,
    }
}
