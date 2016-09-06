using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingAPI.Models
{
    public interface IRatingsRepository
    {
        IEnumerable<Rating> GetAll();
        Rating GetById(int id);
        Rating Add(Rating item);
        void Update(Rating item);
        void Remove(int id);
    }
}
