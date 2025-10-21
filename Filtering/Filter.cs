namespace Filtering
{
    public class Filter<T> : IFilter<T> where T : class
    {
        readonly Edi.EdiClient _EdiClient;
        readonly Emacs.Emacs.EmacsClient _EmacsClient;

        public Filter(Edi.EdiClient ediClient, Emacs.Emacs.EmacsClient emacsClient)
        {
            _EdiClient = ediClient;
            _EmacsClient = emacsClient;
        }
        public Collection<T> FilterExpression(IEnumerable<T> collection, Expression<Func<T, bool>> expression)
        {
            Func<T, bool> compiledExpression = expression.Compile();
            Collection<T> enumerableCollection = (Collection<T>)collection.Where(compiledExpression);
            return enumerableCollection;
        }

        public Collection<T> FilterExpression(Func<T, bool> function, AccessServices accessService)
        {
            ICollection<T> resultCollection = new Collection<T>();
            switch (accessService)
            {
                case AccessServices.EDI:
                    EdiFilterRequest ediRequest = new EdiFilterRequest();
                    ediRequest.FilterExpression = function.ToString();
                    ediRequest.DatabaseList = typeof(T).Name;
                    EdiResponse ediResponse = _EdiClient.FilterEdiDataGrpc(ediRequest);
                    resultCollection = ExtractEdiResponseData(ediResponse);
                    return (Collection<T>)resultCollection;
                case AccessServices.EMACS:
                    EmacsFilterRequest emacsRequest = new EmacsFilterRequest();
                    emacsRequest.FilterExpression = function.ToString();
                    emacsRequest.DatabaseList = typeof(T).Name;
                    EmacsFilterResponse emacsResponse = _EmacsClient.FilterEmacsDataGrpc(emacsRequest);
                    resultCollection = ExtractEmacsResponseData(emacsResponse);
                    return (Collection<T>)resultCollection;

                default:
                throw new NotImplementedException($"AccessService {accessService} not implemented");
            }
        }

        ICollection<T> ExtractEdiResponseData(EdiResponse response)
        {
            Collection<T> results = new Collection<T>();

            // Handle ListEdiGlobalParametersGrpc
            if (TryExtractList(response.ListEdiGlobalParametersGrpc?.EdiGlobalParametersGrpc, results))
            {
                return results;
            }
            
            // Handle ListEdiCustomerParameterGrpc
            if (TryExtractList(response.ListEdiCustomerParameterGrpc?.EdiCustomerParameterGrpc, results))
            {
                return results;
            }

            // Handle ListEdiFileDataUploadGrpc
            if (TryExtractList(response.ListEdiFileDataUploadGrpc?.EdiFileDataUploadGrpc, results))
            {
                return results;
            }

            // Handle ListEdiFileDataUploadDuplicatesGrpc
            if (TryExtractList(response.ListEdiFileDataUploadDuplicatesGrpc?.EdiFileDataUploadDuplicatesGrpc, results))
            {
                return results;
            }

            // Handle ListEdiInvoiceInformationGrpc
            if (TryExtractList(response.ListEdiInvoiceInformationGrpc?.EdiInvoiceInformationGrpc, results))
            {
                return results;
            }

            // Handle ListEdiInvoiceInformationDuplicatesGrpc
            if (TryExtractList(response.ListEdiInvoiceInformationDuplicatesGrpc?.EdiInvoiceInformationDuplicateGrpc, results))
            {
                return results;
            }

            // Handle ListEdiInvoiceUnit4Grpc
            if (TryExtractList(response.ListEdiInvoiceUnit4Grpc?.EdiInvoiceUnit4Grpc, results))
            {
                return results;
            }

            // Handle ListEdiZeroPriceExceptionsGrpc
            if (TryExtractList(response.ListEdiZeroPriceExceptionsGrpc?.EdiZeroPriceExceptionsGrpc, results))
            {
                return results;
            }

            return results;
        }
        ICollection<T> ExtractEmacsResponseData(EmacsFilterResponse response)
        {
            Collection<T> results = new Collection<T>();

            // Handle ListCombinedPartsGrpc
            if (TryExtractList(response.ListCombinedPartsGrpc?.CombinedPartsGrpc, results))
            {
                return results;
            }

            // Handle ListPartCategoryDetailGrpc
            if (TryExtractList(response.ListPartCategoryDetailGrpc?.PartCategoryDetailGrpc, results))
            {
                return results;
            }

            // Handle ListPartClassDetailGrpc
            if (TryExtractList(response.ListPartClassDetailGrpc?.PartClassDetailGrpc, results))
            {
                return results;
            }

            // Handle ListPartGroupsGrpc
            if (TryExtractList(response.ListPartGroupsGrpc?.PartGroupsGrpc, results))
            {
                return results;
            }

            // Handle ListPartGroupsConstGrpc
            if (TryExtractList(response.ListPartGroupsConstGrpc?.PartGroupsConstGrpc, results))
            {
                return results;
            }

            // Handle ListCustomerDataGrpc
            if (TryExtractList(response.ListCustomerDataGrpc?.CustomerDataGrpc, results))
            {
                return results;
            }

            // Handle ListColourCodeGrpc
            if (TryExtractList(response.ListColourCodeGrpc?.ColourCodeGrpc, results))
            {
                return results;
            }

            // Handle ListMaterialGroupsGrpc
            if (TryExtractList(response.ListMaterialGroupsGrpc?.MaterialGroupsGrpc, results))
            {
                return results;
            }

            // Handle ListMaterialTypesGrpc
            if (TryExtractList(response.ListMaterialTypesGrpc?.MaterialTypesGrpc, results))
            {
                return results;
            }

            // Handle ListNPACustomerGrpc
            if (TryExtractList(response.ListNPACustomerGrpc?.NPACustomerGrpc, results))
            {
                return results;
            }

            // Handle ListNPASupplierGrpc
            if (TryExtractList(response.ListNPASupplierGrpc?.NPASupplierGrpc, results))
            {
                return results;
            }

            // Handle ListSuppliersGrpc
            if (TryExtractList(response.ListSuppliersGrpc?.SuppliersGrpc, results))
            {
                return results;
            }

            // Handle ListEmacsRFIViewGrpc
            if (TryExtractList(response.ListEmacsRFIViewGrpc?.EmacsRFIViewGrpc, results))
            {
                return results;
            }

            // Handle ListPARTMSGrpc
            if (TryExtractList(response.ListPARTMSGrpc?.PARTMSGrpc, results))
            {
                return results;
            }

            return results;
        }

        bool TryExtractList<TItem>(IEnumerable<TItem>? items, Collection<T> results) where TItem : class
            {
                if (items != null && typeof(T) == typeof(TItem))
                {
                    foreach (TItem item in items)
                    {
                        results.Add((T)(object)item);
                    }

                    return true;
                }

                return false;
            }
        }
}
