﻿using PrroniaCore.Models;
using PrroniaCore.RepositoryAbstract;
using PrroniaData.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrroniaData.RepositoryConcretes
{
    public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
