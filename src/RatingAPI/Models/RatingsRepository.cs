using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingAPI.Models
{
    public class RatingsRepository : IRatingsRepository
    {
        // TODO: Use EF instead of hard coded list?
        public static List<Rating> _ratings = new List<Rating> {
            new Rating { Id = 1, Name = "C#", Value = 3 },
            new Rating { Id = 2, Name = "JavaScript", Value = 2 },
            new Rating { Id = 3, Name = "CSS", Value = 4 }
        };

        /// <summary>
        ///  Gets all rating-objects
        /// </summary>
        /// <returns>List of all rating-objects</returns>
        public IEnumerable<Rating> GetAll()
        {
            return _ratings;
        }

        /// <summary>
        /// Finds a specific ratings-object by id
        /// </summary>
        /// <param name="id">id of ratings-object to be found</param>
        /// <returns>rating object with matching id</returns>
        public Rating GetById(int id)
        {
            foreach (var item in _ratings)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds a new ratings-item to the DB, also sets the id of the new ratings object
        /// </summary>
        /// <param name="item">ratings-item from client</param>
        public Rating Add(Rating item)
        {
            item.Id = (_ratings.Count > 0) ? _ratings.Last().Id + 1 : 1;
            _ratings.Add(item);
            return item;
        }

        /// <summary>
        /// Selects a ratings-object with matching id and deletes it
        /// </summary>
        /// <param name="id">id of ratings-object to be deleted</param>
        public void Remove(int id)
        {
            foreach (var item in _ratings)
            {
                if (item.Id == id)
                {
                    _ratings.Remove(item);
                    return;
                }
            }
        }

        /// <summary>
        /// Selects a ratings-object with matching id and updates with user input
        /// </summary>
        /// <param name = "item" > updated ratings-object to be inserted</param>
        public void Update(Rating item)
        {
            foreach (var rating in _ratings)
            {
                if (rating.Id == item.Id)
                {
                    rating.Name = item.Name;
                    rating.Value = item.Value;
                }
            }
        }
    }
}
