using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract]
    public class SecurityTransactionCollection
    {
        public SecurityTransactionCollection()
        {
            Transactions = new List<SecurityChangeTransaction>();
        }

        public SecurityTransactionCollection(SecurityTransactionCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            CanLoadMore = collection.CanLoadMore;
            Transactions = collection.Transactions;
        }

        public SecurityTransactionCollection(IEnumerable<SecurityChangeTransaction> collection, bool canLoadMore)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            CanLoadMore = canLoadMore;
            Transactions = collection.ToList();
        }

        public void Add(SecurityTransactionCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            Transactions.AddRange(collection.Transactions);
            CanLoadMore = collection.CanLoadMore;
        }

        public void Add(SecurityChangeTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            Transactions.Add(transaction);
        }

        [DataMember]
        public bool CanLoadMore { get; set; }

        [DataMember]
        public List<SecurityChangeTransaction> Transactions { get; set; }
    }
}
