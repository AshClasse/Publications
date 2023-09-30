using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones.Domain.Repository
{
    public interface IJobsRepository
    {
        void Save(Jobs jobs);
        void Updater(Jobs jobs);
        void Remove(Jobs jobs);
        List<Jobs> GetJobs();
        Jobs GetJosbsID(int ID);

    }
}
