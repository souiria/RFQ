namespace Filtering
{
    public class Filter //: IFilter
    {
        ////readonly Edi.EdiClient _EdiClient;
        ////readonly Emacs.Emacs.EmacsClient _EmacsClient;

        //public Filter(/*Edi.EdiClient ediClient, Emacs.Emacs.EmacsClient emacsClient*/)
        //{
        //    //_EdiClient = ediClient;
        //    //_EmacsClient = emacsClient;
        //}

        //public TResult FilterExpression<TSource, TResult>(IEnumerable<TSource> collection, Expression<Func<TSource, bool>> expression)
        //{
        //    Func<TSource, bool> compiledExpression = expression.Compile();
        //    TResult enumerableCollection = (TResult)collection.Where(compiledExpression);
        //    return enumerableCollection;
        //}

        //public TResult FilterExpression<TItem, TResult>(Func<TItem, bool> function, AccessServices accessService)
        //{
        //    ICollection<TItem> resultCollection = new Collection<TItem>();
        //    switch (accessService)
        //    {
        //        case AccessServices.EDI:
        //            resultCollection = FilterWithService<TItem, EdiFilterRequest, EdiResponse>(
        //                function,
        //                typeof(TItem).Name,
        //                req => _EdiClient.FilterEdiDataGrpc(req),
        //                ExtractEdiResponseData<TItem>
        //            );
        //            return (TResult)resultCollection;

        //        case AccessServices.EMACS:
        //            resultCollection = FilterWithService<TItem, EmacsFilterRequestGrpc, EmacsFilterResponseGrpc>(
        //                function,
        //                typeof(TItem).Name,
        //                req => _EmacsClient.FilterEmacsDataGrpc(req),
        //                ExtractEmacsResponseData<TItem>
        //            );
        //            return (TResult)resultCollection;

        //        default:
        //            throw new NotImplementedException($"AccessService {accessService} not implemented");
        //    }
        //}

        //Collection<TItem> FilterWithService<TItem, TRequest, TResponse>(
        //    Func<TItem, bool> function,
        //    string databaseList,
        //    Func<TRequest, TResponse> serviceCall,
        //    Func<TResponse, ICollection<TItem>> extractData)
        //    where TRequest : new()
        //{
        //    TRequest request = new TRequest();
        //    string functionString = function.ToString() ?? string.Empty;
        //    SetRequestProperties(request, functionString, databaseList);
        //    TResponse? response = serviceCall(request);
        //    ICollection<TItem> resultCollection = extractData(response);
        //    return (Collection<TItem>)resultCollection;
        //}

        //void SetRequestProperties(object request, string filterExpression, string databaseList)
        //{
        //    Type type = request.GetType();
        //    type.GetProperty("FilterExpression")?.SetValue(request, filterExpression);
        //    type.GetProperty("DatabaseList")?.SetValue(request, databaseList);
        //}

        //Collection<TItem> ExtractEdiResponseData<TItem>(EdiResponse response)
        //{
        //    Collection<TItem> results = new Collection<TItem>();

        //    TryExtractList(response.ListEdiGlobalParametersGrpc?.EdiGlobalParametersGrpc, results);
        //    TryExtractList(response.ListEdiCustomerParameterGrpc?.EdiCustomerParameterGrpc, results);
        //    TryExtractList(response.ListEdiFileDataUploadGrpc?.EdiFileDataUploadGrpc, results);
        //    TryExtractList(response.ListEdiFileDataUploadDuplicatesGrpc?.EdiFileDataUploadDuplicatesGrpc, results);
        //    TryExtractList(response.ListEdiInvoiceInformationGrpc?.EdiInvoiceInformationGrpc, results);
        //    TryExtractList(response.ListEdiInvoiceInformationDuplicatesGrpc?.EdiInvoiceInformationDuplicateGrpc, results);
        //    TryExtractList(response.ListEdiInvoiceUnit4Grpc?.EdiInvoiceUnit4Grpc, results);
        //    TryExtractList(response.ListEdiZeroPriceExceptionsGrpc?.EdiZeroPriceExceptionsGrpc, results);

        //    return results;
        //}
        //Collection<TItem> ExtractEmacsResponseData<TItem>(EmacsFilterResponseGrpc response)
        //{
        //    Collection<TItem> results = new Collection<TItem>();

        //    TryExtractList(response.ListCombinedPartsGrpc?.CombinedPartsGrpc, results);
        //    TryExtractList(response.ListPartCategoryDetailGrpc?.PartCategoryDetailGrpc, results);
        //    TryExtractList(response.ListPartClassDetailGrpc?.PartClassDetailGrpc, results);
        //    TryExtractList(response.ListPartGroupsGrpc?.PartGroupsGrpc, results);
        //    TryExtractList(response.ListPartGroupsConstGrpc?.PartGroupsConstGrpc, results);
        //    TryExtractList(response.ListCustomerDataGrpc?.CustomerDataGrpc, results);
        //    TryExtractList(response.ListColourCodeGrpc?.ColourCodeGrpc, results);
        //    TryExtractList(response.ListMaterialGroupsGrpc?.MaterialGroupsGrpc, results);
        //    TryExtractList(response.ListMaterialTypesGrpc?.MaterialTypesGrpc, results);
        //    TryExtractList(response.ListNPACustomerGrpc?.NPACustomerGrpc, results);
        //    TryExtractList(response.ListNPASupplierGrpc?.NPASupplierGrpc, results);
        //    TryExtractList(response.ListSuppliersGrpc?.SuppliersGrpc, results);
        //    TryExtractList(response.ListEmacsRFIViewGrpc?.EmacsRFIViewGrpc, results);
        //    TryExtractList(response.ListPARTMSGrpc?.PARTMSGrpc, results);

        //    return results;
        //}

        //bool TryExtractList<TItem, T>(IEnumerable<TItem>? items, Collection<T> results) where TItem : class
        //{
        //    if (items != null && typeof(T) == typeof(TItem))
        //    {
        //        foreach (TItem item in items)
        //        {
        //            results.Add((T)(object)item);
        //        }

        //        return true;
        //    }

        //    return false;
        //}
    }
}
