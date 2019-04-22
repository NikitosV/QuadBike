using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.Context.CommitProvider
{
    public interface ICommitProvider
    {
        void Save();
    }
}