using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.Context.CommitProvider
{
    public class CommitProvider : ICommitProvider
    {
        private readonly IQuadBikeContext _db;

        public CommitProvider(IQuadBikeContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}