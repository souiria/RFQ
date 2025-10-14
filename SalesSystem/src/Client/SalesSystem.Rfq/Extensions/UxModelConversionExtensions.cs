namespace SalesSystem.Rfq.Extensions
{
    public static class UxModelConversionExtensions

    {
        public static CustomerProjectUx? ToCustomerProjectUx(this ProjectAssociation association)
        {
            if (association == null)
            {
                return null;
            }

            CustomerProjectUx projectAssociation = new CustomerProjectUx();
            projectAssociation.ProjectId = association.CustomerProjectGuid;
            projectAssociation.ProjectName = association.CustomerProjectName;
            projectAssociation.CustomerId = association.CustomerLocationGuid;
            projectAssociation.CustomerName = association.CustomerLocationName;
            projectAssociation.Id = association.Id;
            return projectAssociation;
        }
    }
}
