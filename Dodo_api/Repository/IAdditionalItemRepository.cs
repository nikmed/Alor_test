using System;
using System.Collections.Generic;
using Dodo_api.Models;

namespace Dodo_api.Repository
{
    public interface IAdditionalItemRepository
    {
        void Add(AdditionalItem item);
        IEnumerable<AdditionalItem> GetAll();
        AdditionalItem Find(long ingid);
        AdditionalItem Remove(long ingid);
        void Update(long ingid, AdditionalItem item);
    }
}
