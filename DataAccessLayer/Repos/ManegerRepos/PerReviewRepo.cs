using DataAccessLayer.EF;
using DataAccessLayer.Interfaces.ManegerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.ManegerRepos
{
    internal class PerReviewRepo : Repo, IPerReview<PerformanceReview, int, bool>
    {
        public bool create(PerformanceReview obj)
        {
            throw new NotImplementedException();
        }

        public bool Create(PerformanceReview obj)
        {
            PerformanceReview NewPerReview = new PerformanceReview
            {
                EmployeeID = obj.EmployeeID,
                ReviewDate = DateTime.Now,
                ReviewerID = obj.ReviewerID,
                Feedback = obj.Feedback,
                Rating = obj.Rating
            };
            db.PerformanceReviews.Add(NewPerReview);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.PerformanceReviews.Find(id);
            db.PerformanceReviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<PerformanceReview> GetAll()
        {
            return db.PerformanceReviews.ToList();
        }
    }
}
